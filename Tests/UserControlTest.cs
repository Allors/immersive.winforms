// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextBoxTest.cs" company="allors bvba">
//   Copyright 2008-2014 Allors bvba.
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU Lesser General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU Lesser General Public License for more details.
//   
//   You should have received a copy of the GNU Lesser General Public License
//   along with this program.  If not, see http://www.gnu.org/licenses.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Allors.Immersive.Winforms.Tests
{
    using Allors.Immersive.Winforms.Testers;

    using AllorsTestWindowsAssembly;

    using AssemblyToProcess;

    using NUnit.Framework;

    [TestFixture]
    public class UserControlTest : WinformsTest
    {
        private DefaultForm form;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            this.form = new DefaultForm();
            this.form.Show();
        }

        [Test]
        public void FindTesterByName()
        {
            var tester = new UserControlTester("defaultUserControl1");
            Assert.IsNotNull(tester.Target);
            Assert.IsInstanceOf<DefaultUserControl>(tester.Target);
        }

        [Test]
        public void SameNameOnDifferentParents()
        {
            var button1 = new ButtonTester("button1");

            var defaultUserControl = new UserControlTester("defaultUserControl1");

            var textBox1OnForm = new TextBoxTester(this.form.Name, "textBox1");
            var textBox2OnForm = new TextBoxTester(this.form.Name, "textBox2");
            var textBox1OnUserControl = new TextBoxTester(defaultUserControl.Target.Name, "textBox1");

            textBox1OnForm.Target.Text = "OkForm!";
            button1.Click();

            Assert.AreEqual("OkForm!", textBox1OnForm.Target.Text);
            Assert.AreEqual("OkForm!", textBox2OnForm.Target.Text);
            Assert.AreNotEqual("OkForm!", textBox1OnUserControl.Target.Text);
        }
    }
}