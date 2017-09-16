/*
 * C17_Ex01: FacebookDataTable.cs
 * 
 * Written by:
 * 204311997 - Or Mantzur
 * 200441749 - Dudi Yecheskel 
*/
using System;
using System.Data;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;

namespace C17_Ex01_Dudi_200441749_Or_204311997.DataTables
{
    public abstract class FacebookDataTable : IDisplayableObjectHolder
    {
        protected readonly object r_PopulateRowsLock = new object();
        // Visitor
        private readonly FacebookObjectDisplayer r_FacebookObjectDisplayer = new FacebookObjectDisplayer();
        // observers list
        private readonly List<IRowsPopulatedObserver> r_RowsPopulatedObservers = new List<IRowsPopulatedObserver>();
        // this can be used instead of using interface for observer implementation
        // public event Action PopulateRowsCompleted;

        protected readonly Action NotifyAbstractParentPopulateRowsCompleted;

        public int TotalRows { get; protected set; }

        public DataTable DataTable { get; }

        public object ObjectToDisplay { get; set; }

        protected FacebookDataTable(string i_TableName)
        {
            DataTable = new DataTable(i_TableName);
            // all tables initially have a column that holds the current row object displayed
            DataTable.Columns.Add("ObjectDisplayed", typeof(object));
            // only the abstract parent can invoke an event
            NotifyAbstractParentPopulateRowsCompleted += notifyAllRowsPopulatedObservers;
            InitColumns();
        }

        public string TableName
        {
            get { return DataTable.TableName; }
        }

        protected abstract void InitColumns();

        protected abstract void PopulateRowsImplementation(FacebookObjectCollection<FacebookObject> i_Collection);

        // adds all FacebookObjects of the given collection that are of type T to the data table rows
        public virtual void PopulateRows(FacebookObjectCollection<FacebookObject> i_Collection)
        {
            lock (r_PopulateRowsLock)
            {
                if (DataTable.Rows.Count == 0)
                {
                    FacebookApplication.StartThread(() => PopulateRowsImplementation(i_Collection));
                }
            }
        }
        
        // ========================================= Vistor Method ====================================
        public void DisplaySelectedObject()
        {
            r_FacebookObjectDisplayer.DisplayObject(this);
        }

        // ========================================= Observer Methods ====================================
        public void AddRowsPopulatedObserver(IRowsPopulatedObserver i_NewObserver)
        {
            this.r_RowsPopulatedObservers.Add(i_NewObserver);
        }

        public void RemoveRowsPopulatedObserver(IRowsPopulatedObserver i_ObserverToRemove)
        {
            if (this.r_RowsPopulatedObservers.Contains(i_ObserverToRemove))
            {
                this.r_RowsPopulatedObservers.Remove(i_ObserverToRemove);
            }
        }

        private void notifyAllRowsPopulatedObservers()
        {
            foreach (IRowsPopulatedObserver observer in r_RowsPopulatedObservers)
            {
                observer.AllRowsUpdated();
            }
        }
    }
}
