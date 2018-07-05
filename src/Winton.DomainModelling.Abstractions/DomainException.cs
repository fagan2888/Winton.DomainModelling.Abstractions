﻿// Copyright (c) Winton. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System;

namespace Winton.DomainModelling
{
    /// <inheritdoc />
    /// <summary>
    ///     Represents domain errors.
    /// </summary>
    public class DomainException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DomainException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DomainException(string message)
            : base(message)
        {
        }
    }
}