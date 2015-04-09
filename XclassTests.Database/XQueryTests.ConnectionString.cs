﻿/*
 * Copyright 2015 Fuks Alexander. Contacts: kungfux2010@gmail.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using NUnit.Framework;
using System;
using System.Drawing;
using Xclass.Database;

namespace XclassTests.Database
{
    [TestFixture]
    public partial class XQueryTests
    {
        [Test]
        public void TestDefiningOfTheConnectionString()
        {
            XQuery x = new XQuery(dbType);
            // here is Xclass should perform test connection
            // and save connection string
            x.ConnectionString = sqliteConnectionString;
            Assert.IsNull(x.ErrorMessage);
            Assert.AreEqual(sqliteConnectionString, x.ConnectionString);
        }

        [Test]
        public void TestNoActiveConnectionOnDefiningConnectionString()
        {
            XQuery x = new XQuery(dbType);
            // by default no active connection
            Assert.IsFalse(x.IsActiveConnection);
            // here is Xclass perform test connection
            x.ConnectionString = sqliteConnectionString;
            // connection should be closed after the test
            Assert.IsFalse(x.IsActiveConnection);
        }
    }
}
