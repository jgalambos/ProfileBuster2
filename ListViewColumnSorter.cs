using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace ProfileBuster2 {
    class ListViewColumnSorter : IComparer {
        private int column;
        private SortOrder order;
        public ListViewColumnSorter() {
            column = 0;
            order = SortOrder.Descending;
        }

        public ListViewColumnSorter(int column, SortOrder order) {
            this.column = column;
            this.order = order;
        }

        public int Compare(object x, object y) {
            int temp = 0;
            
            temp = String.Compare(((ListViewItem)x).SubItems[column].Text, ((ListViewItem)y).SubItems[column].Text);

            if (order == SortOrder.Ascending)
                temp *= -1;
            return temp;
        }
    }
}
