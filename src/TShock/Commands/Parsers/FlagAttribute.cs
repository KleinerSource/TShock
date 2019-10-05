﻿// Copyright (c) 2019 Pryaxis & TShock Contributors
// 
// This file is part of TShock.
// 
// TShock is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// TShock is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with TShock.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;

namespace TShock.Commands.Parsers {
    /// <summary>
    /// Specifies that a <see langword="bool" /> parameter should have flag-based parsing.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class FlagAttribute : Attribute {
        /// <summary>
        /// Gets the flags.
        /// </summary>
        public IReadOnlyCollection<string> Flags { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlagAttribute"/> class with the specified flags.
        /// </summary>
        /// <param name="flag">The flag.</param>
        /// <param name="alternateFlags">The alternate flags.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="flag"/> or <paramref name="alternateFlags"/> are <see langword="null" />.
        /// </exception>
        public FlagAttribute(string flag, params string[] alternateFlags) {
            if (flag is null) throw new ArgumentNullException(nameof(flag));

            Flags = new[] {flag}.Concat(alternateFlags ?? throw new ArgumentNullException(nameof(alternateFlags)))
                                .ToList();
        }
    }
}