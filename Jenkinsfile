#!groovy

node {
	step([$class: 'StashNotifier'])
	try {
		stage("Clone") {
			checkout scm
		}

		stage("Restore") {
			bat "dotnet restore --source https://packages/repository/nuget-group-libs/"
		}

		stage("Build") {
			bat("\"${tool 'MSBuild15'}\" /p:Configuration=Release")
		}

		stage("Test") {
			dir("test\\Winton.DomainModelling.Abstractions.Tests") {
				bat("dotnet test Winton.DomainModelling.Abstractions.Tests.csproj --configuration Release --no-restore --no-build")
			}
		}

		stage("Publish") {
			dir("src\\Winton.DomainModelling.Abstractions\\bin") {
				bat("dotnet nuget push **\\*.nupkg --source https://packages/repository/nuget-hosted-libs/")
			}
		}

		stage("Archive") {
			archive "**\\*.nupkg"
		}

		currentBuild.result = "SUCCESS"
	}
	catch (err) {
		currentBuild.result = "FAILURE"
		throw err
	}
	finally{
		step([$class: 'StashNotifier'])
	}
}