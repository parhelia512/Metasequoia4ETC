﻿using System;
using System.Linq;

namespace Metasequoia_4_GenRegNum
{
    internal class Program
    {
        public void Main()
        {
            var reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE", true).CreateSubKey("Tetraface").CreateSubKey("Metasequoia");
            System.Collections.Generic.List<Dic> t3 = new System.Collections.Generic.List<Dic>();
            for (int x = 0; x < 122; x++)
            {
                int temp = AnyNumeToChar(x);
                if (temp != 0)
                {
                    t3.Add(new Dic(x, temp, Convert.ToChar(x)));
                }
            }
            ret:
            string id = "12345E-6789AB-CDEFG";
            string[] CE = id.Select((x => x.ToString())).ToArray();
            for (int i = 0; i < id.Length; i++)
            {
                if (CE[i] != "-" && i != 5)
                {
                    do
                    {
                        CE[i] = t3.Select(a => new { a, Guid = Guid.NewGuid() }).OrderBy(b => b.Guid).Select(c => c.a).ToList()[0].v.ToString();
                    } while (CE[i] == "0");
                }
                else if (i == 5)
                {
                    CE[i] = "E";
                }
            }
            id = "";
            foreach (var tp in CE)
            {
                id = id + tp;
            }
            Dic t = new Dic(id);
            int v39 = (t.Num[7] * t.Num[12] + t.Num[10] * t.Num[11] + t.Num[9] * t.Num[8] + t.Num[0] * t.Num[14] + t.Num[2] * t.Num[18] + t.Num[1] * t.Num[15] + t.Num[3] * t.Num[17] + t.Num[4] * t.Num[16] + 17) % 33 + 1;
            char[] password = new char[7] { '0', '0', '0', '-', '0', '0', Convert.ToChar(AnyAddNum(v39)) };
            int v46 = 73 * t.Num[1];
            int v51 = 12 * t.Num[5] + 512 + v46 + 17693;
            int v55 = 267 * t.Num[12] + 5112 + v51;
            int v59 = v55 + ((t.Num[16] + 8) << 6);
            int v63 = 47 * t.Num[3] + 5842 + v59;
            int v67 = v63 + 9477 * t.Num[9] + 687;
            int v72 = 4798 - 94 * t.Num[8] + v67;
            int v75 = v72 + 10784 - 94 * t.Num[2];
            int v78 = 874 - 15 * t.Num[17];
            int v79 = 14 * t.Num[18] + 3543;
            int v47 = 1241 - 71 * t.Num[11];
            int v52 = 7 * 121 + v47 + 37926;
            int v56 = v52 + 7 * t.Num[14] + 187;
            int v60 = 13 * t.Num[0] + v56 + 6897;
            int v64 = v60 + 13 * t.Num[10] + 764;
            int v68 = 13 * t.Num[4] + 7604 + v64;
            int v71 = 987 - 32 * t.Num[7] + v68;
            int v125 = v71 + 9653 - 16 * t.Num[15];
            int v80 = ((v75 * v78 - v125 * v79) % 64102);
            int v82 = Math.Abs(v80) / 43 % 33 + 1;
            password[2] = Convert.ToChar(AnyAddNum(v82));
            int v126 = v71 + 9653 - 16 * t.Num[15];
            int v87 = 17 * t.Num[17] + 148;
            int v81 = (Int32)(v126 * v78 + v75 * v79) % 15627;
            int v86 = 453 - 7 * t.Num[0];
            int v88 = v80 * v86;
            int v90 = Math.Abs((v88 - v81 * v87) % 316306);
            int v91 = (v90 + 692351) % 33 + 1;
            password[5] = Convert.ToChar(AnyAddNum2(v90, v91));
            int v89 = (v81 * v86 + v87 * v80) % 47891;
            int v94 = Math.Abs(v89);
            int v95 = (v94 + 14632) % 33 + 1;
            password[0] = Convert.ToChar(AnyAddNum2(v94, v95));
            int v100 = (t.Num[16] + AnyNumeToChar(AnyAddNum2(v90, v91)) * t.Num[10]) % 33 + 1;
            password[1] = Convert.ToChar(AnyAddNum(v100));
            int v102 = AnyAddNUm4(Convert.ToChar(t.t[7]));
            int v103 = AnyAddNUm4(Convert.ToChar(password[2]));
            int v104 = AnyAddNUm4(Convert.ToChar(t.t[18]));
            int v105 = (v102 + v103 * v104) % 33 + 1;
            int v106;
            if ((uint)((v102 + v103 * v104) % 33) > 9)
            {
                if ((uint)((v102 + v103 * v104) % 33 - 10) > 7)
                {
                    if ((uint)((v102 + v103 * v104) % 33 - 18) > 4)
                    {
                        if (v105 == 24)
                            v106 = 80;
                        else
                            v106 = (uint)((v102 + v103 * v104) % 33 - 24) > 8 ? 42 : v105 + 57;
                    }
                    else
                    {
                        v106 = v105 + 55;
                    }
                }
                else
                {
                    v106 = v105 + 54;
                }
            }
            else
            {
                v106 = v105 + 47;
            }
            password[4] = Convert.ToChar(v106);
            string oute = "";
            foreach (var tcp in password)
            {
                oute = oute + tcp;
                if (AnyNumeToChar(Convert.ToChar(tcp)) == 0)
                {
                    if (tcp != '-')
                    { goto ret; }
                }
            }
            reg.SetValue("V4ID1", id);
            reg.SetValue("V4ID2", oute);
        }

        public class Dic
        {
            private int AnyNum;
            private int ASKNUM;
            public char v;
            public string[] t;
            public int[] Num;

            public Dic(string p_2)
            {
                t = p_2.Select((x => x.ToString())).ToArray();
                System.Collections.Generic.List<int> temp = new System.Collections.Generic.List<int>();
                for (int i = 0; i < t.Length; i++)
                {
                    temp.Add(ChartoNum(Convert.ToChar(t[i])));
                }
                Num = temp.ToArray();
            }

            public Dic(int x, int temp, char v)
            {
                this.AnyNum = x;
                this.ASKNUM = temp;
                this.v = v;
            }
        }

        private static int AnyNumeToChar(int v23)
        {
            int v24 = 0;
            if ((UInt16)(v23 - 48) > 9u)
            {
                if ((UInt16)(v23 - 65) > 7u)
                {
                    if ((UInt16)(v23 - 74) > 4u)
                    {
                        if ((UInt16)v23 == 80)
                            v24 = 24;
                        v24 = (UInt16)(v23 - 82) > 8u ? 0 : (UInt16)v23 - 57;
                    }
                    else
                    {
                        v24 = (UInt16)v23 - 55;
                    }
                }
                else
                {
                    v24 = (UInt16)v23 - 54;
                }
            }
            else
            {
                v24 = (UInt16)v23 - 47;
            }
            return v24;
        }

        private static int AnyNumeToChar2(int v23)
        {
            int v24 = 0;
            if ((UInt16)(v23 - 1) > 9)
            {
                if ((UInt16)(v23 - 11) > 7)
                {
                    if ((UInt16)(v23 - 19) > 4)
                    {
                        if ((UInt16)v23 == 80) v24 = 24;
                        v24 = (UInt16)(v23 - 25) > 8 ? 0 : (UInt16)v23 + 57;
                    }
                    else
                    {
                        v24 = (UInt16)v23 + 55;
                    }
                }
                else
                {
                    v24 = (UInt16)v23 + 54;
                }
            }
            else
            {
                v24 = (UInt16)v23 + 47;
            }
            return v24;
        }

        private static int ChartoNum(char v19)
        {
            int v136;
            if ((UInt16)(v19 - 48) > 9u)
            {
                if ((UInt16)(v19 - 65) > 7u)
                {
                    if ((UInt16)(v19 - 74) > 4u)
                    {
                        if (v19 == 80)
                            v136 = 24;
                        else
                            v136 = (UInt16)(v19 - 82) > 8u ? 0 : v19 - 57;
                    }
                    else
                    {
                        v136 = v19 - 55;
                    }
                }
                else
                {
                    v136 = v19 - 54;
                }
            }
            else
            {
                v136 = v19 - 47;
            }
            return v136;
        }

        private static int AnyAddNum(int v39)
        {
            int v40;
            if ((int)(v39 - 1) > 9)
            {
                if ((int)(v39 - 11) > 7)
                {
                    if ((int)(v39 - 19) > 4)
                    {
                        if (v39 == 24)
                            v40 = 80;
                        else
                            v40 = (int)(v39 - 25) > 8 ? 42 : v39 + 57;
                    }
                    else
                    {
                        v40 = v39 + 55;
                    }
                }
                else
                {
                    v40 = v39 + 54;
                }
            }
            else
            {
                v40 = v39 + 47;
            }
            return v40;
        }

        private static int AnyAddNum2(int v90, int V91)
        {
            int V92;
            if ((uint)((v90 + 692351) % 33) > 9)
            {
                if ((uint)((v90 + 692351) % 33 - 10) > 7)
                {
                    if ((uint)((v90 + 692351) % 33 - 18) > 4)
                    {
                        if (V91 == 24)
                            V92 = 80;
                        else
                            V92 = (uint)((v90 + 692351) % 33 - 24) > 8 ? 42 : V91 + 57;
                    }
                    else
                    {
                        V92 = V91 + 55;
                    }
                }
                else
                {
                    V92 = V91 + 54;
                }
            }
            else
            {
                V92 = V91 + 47;
            }
            return V92;
        }

        private static int AnyAddNum3(int v90, int V91)
        {
            int V92;
            if ((uint)((v90 + 14632) % 33) > 9)
            {
                if ((uint)((v90 + 14632) % 33 - 10) > 7)
                {
                    if ((uint)((v90 + 14632) % 33 - 18) > 4)
                    {
                        if (V91 == 24)
                            V92 = 80;
                        else
                            V92 = (uint)((v90 + 14632) % 33 - 24) > 8 ? 42 : V91 + 57;
                    }
                    else
                    {
                        V92 = V91 + 55;
                    }
                }
                else
                {
                    V92 = V91 + 54;
                }
            }
            else
            {
                V92 = V91 + 47;
            }
            return V92;
        }

        private static int AnyAddNUm4(int a1)
        {
            int result;
            if ((UInt16)(a1 - 48) > 9u)
            {
                if ((UInt16)(a1 - 65) > 7u)
                {
                    if ((UInt16)(a1 - 74) > 4u)
                    {
                        if (a1 == 80)
                        {
                            result = 24;
                        }
                        else if ((UInt16)(a1 - 82) > 8u)
                        {
                            result = 0;
                        }
                        else
                        {
                            result = a1 - 57;
                        }
                    }
                    else
                    {
                        result = a1 - 55;
                    }
                }
                else
                {
                    result = a1 - 54;
                }
            }
            else
            {
                result = a1 - 47;
            }
            return result;
        }
    }
}