using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeChallenge.Models.Tests
{
    [TestClass()]
    public class CaseTests
    {
        [TestMethod()]
        public void IsExpiredTest()
        {
            Case caseTest = new Case();
            caseTest.ExpDate = new DateTime(2019, 1, 1);

            try
            {
                caseTest.IsExpired();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return;
            }

        }

        [TestMethod()]
        public void QtyOutofRequested()
        {
            Procedure procedure = new Procedure(12, "Test", 1, 1, "Modifiers");
            try
            {
                procedure.QtyOutofRequested();
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return;
            }

        }

        [TestMethod()]
        public void QtyRequestedZero()
        {
            Procedure procedure = new Procedure();
            procedure.QtyRequested = -1;
            try
            {
                procedure.QtyRequestedZero();
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.Fail(e.Message);
                return;
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
                return;
            }
        }
    }
}