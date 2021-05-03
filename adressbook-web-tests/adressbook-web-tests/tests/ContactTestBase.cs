using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUi_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<PropertiesContact> fromUI = app.Contacts.GetContactList();
                List<PropertiesContact> fromDB = PropertiesContact.GetAll();
                fromUI.Sort();
                fromDB.Sort();
                Assert.AreEqual(fromUI, fromDB);
            }

        }
    }
}
