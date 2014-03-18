using System;
using System.Collections.Generic;
using System.Text;

namespace BKI_HRM.HeThong
{
    class collection
    {
        public string[] s;
        int index;

        public collection(int ip_length) {
            s = new string[ip_length];
            index = 0;
        }

        public int getIndex() {
            return index;
        }

        public string getString() {
            return s[1];
        }

        public void insert(string ip_str) {
            s[index] = ip_str;
            index++;
        }

        public int countInANotInB(collection ip_coll) {
            int v_count = 0;
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < ip_coll.index; j++)
                {
                    if (s[i] == ip_coll.s[j])
                    {
                        v_count++;
                        break;
                    }
                }
            }
            return index - v_count;
        }

        public int countNotInAInB(collection ip_coll)
        {
            int v_count = 0;
            for (int i = 0; i < index; i++)
            {
                for (int j = 0; j < ip_coll.index; j++)
                {
                    if (s[i] == ip_coll.s[j])
                    {
                        v_count++;
                        break;
                    }
                }
            }
            return ip_coll.index - v_count;
        }

        public collection InANotInB(collection ip_coll) {
            collection v_result = new collection(countInANotInB(ip_coll));
            for (int i = 0; i < index; i++)
            {
                int j;
                for (j = 0; j < ip_coll.index; j++)
                {
                    if (s[i] == ip_coll.s[j])
                    {
                        break;
                    }
                }
                if (j == ip_coll.index)
                {
                    v_result.insert(s[i]);
                }
            }
            return v_result;
        }

        public collection NotInAInB(collection ip_coll)
        {
            collection v_result = new collection(countNotInAInB(ip_coll));
            for (int i = 0; i < ip_coll.index; i++)
            {
                int j;
                for (j = 0; j < index; j++)
                {
                    if (s[j] == ip_coll.s[i])
                    {
                        break;
                    }
                }
                if (j == index)
                {
                    v_result.insert(ip_coll.s[i]);
                }
            }
            return v_result;
        }
    }
}
