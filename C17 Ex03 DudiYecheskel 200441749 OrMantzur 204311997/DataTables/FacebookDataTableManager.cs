/*
 * C17_Ex01: FacebookDataTableManager.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Collections.Generic;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    using System.Windows.Forms;

    public class FacebookDataTableManager
    {
        private readonly List<FacebookDataTable> r_DataTables = new List<FacebookDataTable>();

        public FacebookDataTableManager(IRowsPopulatedObserver i_PopulateRowsCompletedObserver)
        {
            foreach (eFacebookDataTableType tableType in Enum.GetValues(typeof(eFacebookDataTableType)))
            {
                FacebookDataTable newTable = FacebookDataTableFactory.CreateTable(tableType);
                newTable.AddRowsPopulatedObserver(i_PopulateRowsCompletedObserver);
                r_DataTables.Add(newTable);
            }
        } 

        public FacebookDataTable[] GetDataTables()
        {
            return r_DataTables.ToArray();
        }
    }
}
