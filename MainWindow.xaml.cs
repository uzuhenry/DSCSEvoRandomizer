using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.IO.Compression;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DSCS_Evolution_Randomizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BoxtopeEvos.Items.Add(1); BoxtopeEvos.Items.Add(2); BoxtopeEvos.Items.Add(3); BoxtopeEvos.Items.Add(4); BoxtopeEvos.Items.Add(5); BoxtopeEvos.Items.Add(6);
            BoxtopeDevos.Items.Add(1); BoxtopeDevos.Items.Add(2); BoxtopeDevos.Items.Add(3); BoxtopeDevos.Items.Add(4); BoxtopeDevos.Items.Add(5); BoxtopeDevos.Items.Add(6);
        }

        //strings iniciales
        public string evo_cond_para =   @"id,condType1,condValue1,condUnk1,condType2,condValue2,condUnk2,condType3,condValue3,condUnk3,condType4,condValue4,condUnk4,condType5,condValue5,condUnk5,condType6,condValue6,condUnk6,condType7,condValue7,condUnk7,condType8,condValue8,condUnk8,condType9,condValue9,condUnk9,condType10,condValue10,condUnk10
901,1,60,0,4,150,0,5,170,0,6,135,0,8,80,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
902,1,60,0,4,120,0,6,135,0,7,150,0,8,80,0,9,50,0,0,0,0,0,0,0,0,0,0,0,0,0
903,1,60,0,3,100,0,6,120,0,7,140,0,8,80,0,13,743,0,0,0,0,0,0,0,0,0,0,0,0,0
904,1,60,0,4,200,0,6,150,0,7,150,0,8,40,0,9,100,0,12,27,0,12,135,0,0,0,0,0,0,0
905,1,60,0,4,140,0,5,140,0,6,140,0,8,80,0,9,50,0,0,0,0,0,0,0,0,0,0,0,0,0
761,1,9,0,4,30,0,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
762,1,9,0,4,30,0,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
763,1,9,0,4,30,0,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
764,1,9,0,4,30,0,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
765,1,9,0,4,30,0,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
419,13,732,0,1,55,0,2,1600,0,5,150,0,7,150,0,8,20,0,13,419,0,0,0,0,0,0,0,0,0,0
743,13,739,0,1,60,0,3,100,0,6,120,0,7,140,0,8,80,0,13,743,0,0,0,0,0,0,0,0,0,0
675,13,678,0,1,50,0,4,130,0,7,160,0,8,20,0,9,80,0,13,675,0,0,0,0,0,0,0,0,0,0
40,1,60,0,2,1700,0,3,140,0,6,180,0,8,80,0,13,40,0,0,0,0,0,0,0,0,0,0,0,0,0";
        public string digi_como_para =  @"id,level,attribute,type,unk1,unk2,unk3,unk4,unk5,unk6,unk7,unk8,unk9,unk10,unk11,unk12,unk13,unk14,unk15,unk16,unk17,fieldGuideId,unk19,unk20,unk21
761,3,1,2,18,17,4,130,3,0,0,2,1,312,10,187,7,2,1,0,-1,18,18,18,0
762,3,1,2,18,17,4,130,3,0,0,2,1,312,10,187,7,2,1,0,-1,18,18,18,0
763,3,1,2,18,17,4,130,3,0,0,2,1,312,10,187,7,2,1,0,-1,18,18,18,0
764,3,1,2,18,17,4,130,3,0,0,2,1,312,10,187,7,2,1,0,-1,18,18,18,0
765,3,1,2,18,17,4,130,3,0,0,2,1,312,10,187,7,2,1,0,-1,18,18,18,0";
        public string ui_mon_para =     @"ID,Unk1,Unk2
761,7,0
762,7,0
763,7,0
764,7,0
765,7,0";

        public string evos_header =     "id,digi1,digi2,digi3,digi4,digi5,digi6";

        public string metadatacontent = "{\n\"Name\": \"RandomEvolutions\",\n\"Author\": \"Loud & Uzuhenry\",\n\"Version\": \"1.0\",\n\"Category\": \"Evolution\",\n\"Description\": \"Gives every Digimon a Random Evolution-Degeneration.\"\n}";

        public List<int> calistaBaby = new List<int>();
        public List<int> calistaBaby2 = new List<int>();
        public List<int> calistaChild = new List<int>();
        public List<int> calistaAdult = new List<int>();
        public List<int> calistaPerfect = new List<int>();
        public List<int> calistaUltimate = new List<int>();
        public List<int> calistaUltimateplus = new List<int>();
        public List<int> calistaDigimones = new List<int>();

        private void Botonrando_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                SetupdelasListas();
                int[] bufferinodeid = new int[6];
                for(int h = 0; h < 6; h++)
                {
                    bufferinodeid[h] = 0;
                }
                string digievos = evos_header;
                bool doneterepe = true;
                int sx = 0;
                int chosenid = 0;
                bool estarepe = false;
                string digidevos = evos_header;
                bool cowabunga =(bool)Botoncillodelcaos.IsChecked;
                bool randonumberevos = (bool)Botoncillodelrepe.IsChecked;
                int topeevos = BoxtopeEvos.SelectedIndex;
                int topedevos = BoxtopeDevos.SelectedIndex;


                calistaDigimones.AddRange(calistaBaby);
                    calistaDigimones.AddRange(calistaBaby2);
                    calistaDigimones.AddRange(calistaChild);
                    calistaDigimones.AddRange(calistaAdult);
                    calistaDigimones.AddRange(calistaPerfect);
                    calistaDigimones.AddRange(calistaUltimate);
                    calistaDigimones.AddRange(calistaUltimateplus);


                //Lista de evos Baby
                for (int i = 0; i < calistaBaby.Count; i++)
                 {
                    digievos +="\n"+ calistaBaby[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count-1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += ","+chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe =false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaBaby2.Count - 1);
                            chosenid = calistaBaby2[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= 1)
                            {
                                doneterepe = false;
                                for(int k = 0; k < (6-sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Baby2
                for (int i = 0; i < calistaBaby2.Count; i++)
                {
                    digievos += "\n" + calistaBaby2[i];
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaChild.Count - 1);
                            chosenid = calistaChild[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= Math.Min(3,BoxtopeEvos.SelectedIndex + 1))
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Child
                for (int i = 0; i < calistaChild.Count; i++)
                {
                    digievos += "\n" + calistaChild[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaAdult.Count - 1);
                            chosenid = calistaAdult[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Adult
                for (int i = 0; i < calistaAdult.Count; i++)
                {
                    digievos += "\n" + calistaAdult[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaPerfect.Count - 1);
                            chosenid = calistaPerfect[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Perfect
                for (int i = 0; i < calistaPerfect.Count; i++)
                {
                    digievos += "\n" + calistaPerfect[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaUltimate.Count - 1);
                            chosenid = calistaUltimate[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Ultimate
                for (int i = 0; i < calistaUltimate.Count; i++)
                {
                    digievos += "\n" + calistaUltimate[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topeevos);
                        BoxtopeEvos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeEvos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaUltimateplus.Count - 1);
                            chosenid = calistaUltimateplus[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digievos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digievos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }

                //      TERMINADA
                //      Lista de Evoluciones TERMINADA
                //      TERMINADA

                //Lista de devos Ultimateplus
                for (int i = 0; i < calistaUltimateplus.Count; i++)
                {
                    digidevos += "\n" + calistaUltimateplus[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaUltimate.Count - 1);
                            chosenid = calistaUltimate[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de devos Baby2
                for (int i = 0; i < calistaBaby2.Count; i++)
                {
                    digidevos += "\n" + calistaBaby2[i];
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaBaby.Count - 1);
                            chosenid = calistaBaby[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de devos Child
                for (int i = 0; i < calistaChild.Count; i++)
                {
                    digidevos += "\n" + calistaChild[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaBaby2.Count - 1);
                            chosenid = calistaBaby2[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= Math.Min(3,BoxtopeDevos.SelectedIndex + 1))
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de devos Adult
                for (int i = 0; i < calistaAdult.Count; i++)
                {
                    digidevos += "\n" + calistaAdult[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaChild.Count - 1);
                            chosenid = calistaChild[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Perfect
                for (int i = 0; i < calistaPerfect.Count; i++)
                {
                    digidevos += "\n" + calistaPerfect[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaAdult.Count - 1);
                            chosenid = calistaAdult[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }
                }
                //Lista de evos Ultimate
                for (int i = 0; i < calistaUltimate.Count; i++)
                {
                    digidevos += "\n" + calistaUltimate[i].ToString();
                    doneterepe = true;
                    sx = 0;
                    if (randonumberevos)
                    {
                        Random ra = new Random();
                        int raInt = ra.Next(0, topedevos);
                        BoxtopeDevos.SelectedIndex = raInt;
                    }
                    //ponemos una nueva linea
                    if (cowabunga)
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaDigimones.Count - 1);
                            chosenid = calistaDigimones[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                                doneterepe = false;
                            }
                        }
                    }
                    else
                    {
                        while (doneterepe)
                        {
                            estarepe = false;
                            Random r = new Random();
                            int rInt = r.Next(0, calistaPerfect.Count - 1);
                            chosenid = calistaPerfect[rInt];
                            for (int j = 0; j < 6; j++)
                            {
                                if (j != sx)
                                {
                                    if (chosenid == bufferinodeid[j])
                                    {
                                        estarepe = true;
                                    }
                                }
                            }
                            if (!estarepe)
                            {
                                bufferinodeid[sx] = chosenid;
                                digidevos += "," + chosenid;
                                sx++;
                            }
                            if (sx >= BoxtopeDevos.SelectedIndex + 1)
                            {
                                doneterepe = false;
                                for (int k = 0; k < (6 - sx); k++)
                                {
                                    digidevos += ",0";
                                }
                            }
                        }
                    }
                    //hemos puesto la línea
                    estarepe = false;
                    for (int h = 0; h < 6; h++)
                    {
                        bufferinodeid[h] = 0;
                    }

                    
                }
                // Fin de archivos, hora del dumpeo

                string locationforfiles = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf("\\"));
                string folderlocation = "";
                string subfolderlocation = "";
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding csver = Encoding.GetEncoding(1252);

                //creamos carpeta para el zip
                if (!Directory.Exists(locationforfiles + "\\mod"))
                {
                    Directory.CreateDirectory(locationforfiles + "\\mod");
                }
                folderlocation = locationforfiles + "\\mod";
                //creamos metadata
                using (FileStream fs = File.Create(folderlocation + "\\METADATA.json"))
                {
                    Byte[] textofile = new UTF8Encoding(true).GetBytes(metadatacontent);
                    fs.Write(textofile, 0, textofile.Length);
                }
                //creamos carpeta modfiles
                if (!Directory.Exists(folderlocation + "\\modfiles"))
                {
                    Directory.CreateDirectory(folderlocation + "\\modfiles");
                }
                folderlocation = folderlocation + "\\modfiles";
                //creamos carpeta data
                if (!Directory.Exists(folderlocation + "\\data"))
                {
                    Directory.CreateDirectory(folderlocation + "\\data");
                }
                folderlocation = folderlocation + "\\data";
                //creamos carpeta ui_mon_param_info.mbe
                if (!Directory.Exists(folderlocation + "\\ui_mon_param_info.mbe"))
                {
                    Directory.CreateDirectory(folderlocation + "\\ui_mon_param_info.mbe");
                }
                subfolderlocation = folderlocation + "\\ui_mon_param_info.mbe";
                // creamos Field.csv
                using (FileStream fs = File.Create(subfolderlocation + "\\Field.csv"))
                {
                    Byte[] textofile = csver.GetBytes(ui_mon_para);
                    fs.Write(textofile, 0, textofile.Length);
                }
                //creamos carpeta evolution_conditon_para.mbe
                if (!Directory.Exists(folderlocation + "\\evolution_condition_para.mbe"))
                {
                    Directory.CreateDirectory(folderlocation + "\\evolution_condition_para.mbe");
                }
                subfolderlocation = folderlocation + "\\evolution_condition_para.mbe";
                // creamos digimon.csv
                using (FileStream fs = File.Create(subfolderlocation + "\\digimon.csv"))
                {
                    Byte[] textofile = csver.GetBytes(evo_cond_para);
                    fs.Write(textofile, 0, textofile.Length);
                }
                //creamos carpeta digimon_common_para.mbe
                if (!Directory.Exists(folderlocation + "\\digimon_common_para.mbe"))
                {
                    Directory.CreateDirectory(folderlocation + "\\digimon_common_para.mbe");
                }
                subfolderlocation = folderlocation + "\\digimon_common_para.mbe";
                // creamos digimon.csv
                using (FileStream fs = File.Create(subfolderlocation + "\\digimon.csv"))
                {
                    Byte[] textofile = csver.GetBytes(digi_como_para);
                    fs.Write(textofile, 0, textofile.Length);
                }
                //creamos carpeta evolution_next_para.mbe
                if (!Directory.Exists(folderlocation + "\\evolution_next_para.mbe"))
                {
                    Directory.CreateDirectory(folderlocation + "\\evolution_next_para.mbe");
                }
                subfolderlocation = folderlocation + "\\evolution_next_para.mbe";
                // creamos digimon.csv
                using (FileStream fs = File.Create(subfolderlocation + "\\digimon.csv"))
                {
                    Byte[] textofile = csver.GetBytes(digievos);
                    fs.Write(textofile, 0, textofile.Length);
                }
                //creamos carpeta degeneration_para.mbe
                if (!Directory.Exists(folderlocation + "\\degeneration_para.mbe"))
                {
                    Directory.CreateDirectory(folderlocation + "\\degeneration_para.mbe");
                }
                subfolderlocation = folderlocation + "\\degeneration_para.mbe";
                // creamos digimon.csv
                using (FileStream fs = File.Create(subfolderlocation + "\\digimon.csv"))
                {
                    Byte[] textofile = csver.GetBytes(digidevos);
                    fs.Write(textofile, 0, textofile.Length);
                }

                //y ahora el zip
                string zipfilename = saveFileDialog1.FileName;
                if (zipfilename.Contains("."))
                {
                    if (zipfilename.Substring(zipfilename.LastIndexOf("."), 4) != ".zip")
                    {
                        zipfilename += ".zip";
                    }
                }
                else
                {
                    zipfilename += ".zip";
                }
                ZipFile.CreateFromDirectory(locationforfiles + "\\mod", zipfilename);

                //limpiamos
                if (Directory.Exists(locationforfiles + "\\mod"))
                {
                    Directory.Delete(locationforfiles + "\\mod", true);
                }
            }
        }

        public void SetupdelasListas()
        {
            //Setup de las listas
            calistaBaby.Clear();
            calistaChild.Clear();
            calistaBaby2.Clear();
            calistaAdult.Clear();
            calistaPerfect.Clear();
            calistaUltimate.Clear();
            calistaUltimateplus.Clear();
            calistaDigimones.Clear();

            //Lista Baby
            calistaBaby.Add(629); calistaBaby.Add(387); calistaBaby.Add(437);
            calistaBaby.Add(317); calistaBaby.Add(320);

            //Lista Baby2
            calistaBaby2.Add(62); calistaBaby2.Add(322); calistaBaby2.Add(512);
            calistaBaby2.Add(438); calistaBaby2.Add(631); calistaBaby2.Add(325);
            calistaBaby2.Add(515); calistaBaby2.Add(567); calistaBaby2.Add(510);
            calistaBaby2.Add(514); calistaBaby2.Add(388); calistaBaby2.Add(321);

            //Lista Child
            calistaChild.Add(50); calistaChild.Add(143); calistaChild.Add(63);
            calistaChild.Add(707); calistaChild.Add(81); calistaChild.Add(564);
            calistaChild.Add(582); calistaChild.Add(55); calistaChild.Add(569);
            calistaChild.Add(151); calistaChild.Add(713); calistaChild.Add(90);
            calistaChild.Add(53); calistaChild.Add(626); calistaChild.Add(595);
            calistaChild.Add(111);
            calistaChild.Add(343);
            calistaChild.Add(709);
            calistaChild.Add(697);
            calistaChild.Add(728);
            calistaChild.Add(20);
            calistaChild.Add(701);
            calistaChild.Add(303);
            calistaChild.Add(708);
            calistaChild.Add(457);
            calistaChild.Add(208);
            calistaChild.Add(112);
            calistaChild.Add(9);
            calistaChild.Add(96);
            calistaChild.Add(687);
            calistaChild.Add(348);
            calistaChild.Add(97);
            calistaChild.Add(307);
            calistaChild.Add(705);
            calistaChild.Add(42);
            calistaChild.Add(114);
            calistaChild.Add(361);
            calistaChild.Add(389);
            calistaChild.Add(706);
            calistaChild.Add(607);
            calistaChild.Add(458);
            calistaChild.Add(56);
            calistaChild.Add(390);
            calistaChild.Add(2);
            calistaChild.Add(391);
            calistaChild.Add(750);
            calistaChild.Add(392);
            calistaChild.Add(190);
            calistaChild.Add(781);
            calistaChild.Add(682);
            calistaChild.Add(761);
            calistaChild.Add(762);
            calistaChild.Add(763);
            calistaChild.Add(764);
            calistaChild.Add(765);

            //Lista Adult
            calistaAdult.Add(730);
            calistaAdult.Add(758);
            calistaAdult.Add(15);
            calistaAdult.Add(676);
            calistaAdult.Add(64);
            calistaAdult.Add(711);
            calistaAdult.Add(344);
            calistaAdult.Add(377);
            calistaAdult.Add(680);
            calistaAdult.Add(393);
            calistaAdult.Add(11);
            calistaAdult.Add(365);
            calistaAdult.Add(87);
            calistaAdult.Add(394);
            calistaAdult.Add(341);
            calistaAdult.Add(760);
            calistaAdult.Add(68);
            calistaAdult.Add(304);
            calistaAdult.Add(455);
            calistaAdult.Add(710);
            calistaAdult.Add(12);
            calistaAdult.Add(714);
            calistaAdult.Add(395);
            calistaAdult.Add(78);
            calistaAdult.Add(630);
            calistaAdult.Add(326);
            calistaAdult.Add(712);
            calistaAdult.Add(398);
            calistaAdult.Add(367);
            calistaAdult.Add(399);
            calistaAdult.Add(729);
            calistaAdult.Add(218);
            calistaAdult.Add(209);
            calistaAdult.Add(113);
            calistaAdult.Add(5);
            calistaAdult.Add(452);
            calistaAdult.Add(30);
            calistaAdult.Add(58);
            calistaAdult.Add(347);
            calistaAdult.Add(130);
            calistaAdult.Add(54);
            calistaAdult.Add(313);
            calistaAdult.Add(14);
            calistaAdult.Add(91);
            calistaAdult.Add(16);
            calistaAdult.Add(698);
            calistaAdult.Add(755);
            calistaAdult.Add(621);
            calistaAdult.Add(759);
            calistaAdult.Add(363);
            calistaAdult.Add(92);
            calistaAdult.Add(93);
            calistaAdult.Add(102);
            calistaAdult.Add(349);
            calistaAdult.Add(396);
            calistaAdult.Add(375);
            calistaAdult.Add(70);
            calistaAdult.Add(308);
            calistaAdult.Add(115);
            calistaAdult.Add(13);
            calistaAdult.Add(397);
            calistaAdult.Add(22);
            calistaAdult.Add(752);
            calistaAdult.Add(43);
            calistaAdult.Add(314);
            calistaAdult.Add(702);
            calistaAdult.Add(10);
            calistaAdult.Add(369);
            calistaAdult.Add(370);
            calistaAdult.Add(548);
            calistaAdult.Add(25);
            calistaAdult.Add(590);
            calistaAdult.Add(72);
            calistaAdult.Add(3);
            calistaAdult.Add(77);
            calistaAdult.Add(454);
            calistaAdult.Add(191);
            calistaAdult.Add(783);
            calistaAdult.Add(716);

            //Lista Perfect
            calistaPerfect.Add(305);
            calistaPerfect.Add(65);
            calistaPerfect.Add(731);
            calistaPerfect.Add(342);
            calistaPerfect.Add(756);
            calistaPerfect.Add(627);
            calistaPerfect.Add(85);
            calistaPerfect.Add(210);
            calistaPerfect.Add(679);
            calistaPerfect.Add(400);
            calistaPerfect.Add(311);
            calistaPerfect.Add(148);
            calistaPerfect.Add(401);
            calistaPerfect.Add(309);
            calistaPerfect.Add(681);
            calistaPerfect.Add(402);
            calistaPerfect.Add(44);
            calistaPerfect.Add(727);
            calistaPerfect.Add(211);
            calistaPerfect.Add(403);
            calistaPerfect.Add(26);
            calistaPerfect.Add(4);
            calistaPerfect.Add(719);
            calistaPerfect.Add(723);
            calistaPerfect.Add(379);
            calistaPerfect.Add(720);
            calistaPerfect.Add(79);
            calistaPerfect.Add(404);
            calistaPerfect.Add(6);
            calistaPerfect.Add(345);
            calistaPerfect.Add(116);
            calistaPerfect.Add(405);
            calistaPerfect.Add(129);
            calistaPerfect.Add(84);
            calistaPerfect.Add(23);
            calistaPerfect.Add(374);
            calistaPerfect.Add(406);
            calistaPerfect.Add(699);
            calistaPerfect.Add(376);
            calistaPerfect.Add(33);
            calistaPerfect.Add(407);
            calistaPerfect.Add(718);
            calistaPerfect.Add(576);
            calistaPerfect.Add(408);
            calistaPerfect.Add(409);
            calistaPerfect.Add(41);
            calistaPerfect.Add(596);
            calistaPerfect.Add(410);
            calistaPerfect.Add(82);
            calistaPerfect.Add(584);
            calistaPerfect.Add(753);
            calistaPerfect.Add(177);
            calistaPerfect.Add(411);
            calistaPerfect.Add(21);
            calistaPerfect.Add(101);
            calistaPerfect.Add(59);
            calistaPerfect.Add(31);
            calistaPerfect.Add(74);
            calistaPerfect.Add(412);
            calistaPerfect.Add(132);
            calistaPerfect.Add(134);
            calistaPerfect.Add(302);
            calistaPerfect.Add(327);
            calistaPerfect.Add(364);
            calistaPerfect.Add(413);
            calistaPerfect.Add(61);
            calistaPerfect.Add(721);
            calistaPerfect.Add(71);
            calistaPerfect.Add(73);
            calistaPerfect.Add(722);
            calistaPerfect.Add(359);
            calistaPerfect.Add(39);
            calistaPerfect.Add(107);
            calistaPerfect.Add(140);
            calistaPerfect.Add(715);
            calistaPerfect.Add(726);
            calistaPerfect.Add(192);
            calistaPerfect.Add(751);

            //Lista Ultimate
            calistaUltimate.Add(66);
            calistaUltimate.Add(416);
            calistaUltimate.Add(417);
            calistaUltimate.Add(451);
            calistaUltimate.Add(732);
            calistaUltimate.Add(419);
            calistaUltimate.Add(346);
            calistaUltimate.Add(773);
            calistaUltimate.Add(117);
            calistaUltimate.Add(600);
            calistaUltimate.Add(27);
            calistaUltimate.Add(421);
            calistaUltimate.Add(744);
            calistaUltimate.Add(677);
            calistaUltimate.Add(150);
            calistaUltimate.Add(422);
            calistaUltimate.Add(688);
            calistaUltimate.Add(127);
            calistaUltimate.Add(754);
            calistaUltimate.Add(423);
            calistaUltimate.Add(32);
            calistaUltimate.Add(704);
            calistaUltimate.Add(83);
            calistaUltimate.Add(734);
            calistaUltimate.Add(774);
            calistaUltimate.Add(735);
            calistaUltimate.Add(48);
            calistaUltimate.Add(424);
            calistaUltimate.Add(425);
            calistaUltimate.Add(749);
            calistaUltimate.Add(94);
            calistaUltimate.Add(737);
            calistaUltimate.Add(86);
            calistaUltimate.Add(213);
            calistaUltimate.Add(315);
            calistaUltimate.Add(741);
            calistaUltimate.Add(771);
            calistaUltimate.Add(745);
            calistaUltimate.Add(440);
            calistaUltimate.Add(128);
            calistaUltimate.Add(733);
            calistaUltimate.Add(632);
            calistaUltimate.Add(38);
            calistaUltimate.Add(126);
            calistaUltimate.Add(738);
            calistaUltimate.Add(700);
            calistaUltimate.Add(739);
            calistaUltimate.Add(743);
            calistaUltimate.Add(19);
            calistaUltimate.Add(75);
            calistaUltimate.Add(426);
            calistaUltimate.Add(60);
            calistaUltimate.Add(36);
            calistaUltimate.Add(49);
            calistaUltimate.Add(427);
            calistaUltimate.Add(428);
            calistaUltimate.Add(69);
            calistaUltimate.Add(175);
            calistaUltimate.Add(429);
            calistaUltimate.Add(214);
            calistaUltimate.Add(450);
            calistaUltimate.Add(306);
            calistaUltimate.Add(35);
            calistaUltimate.Add(439);
            calistaUltimate.Add(310);
            calistaUltimate.Add(453);
            calistaUltimate.Add(431);
            calistaUltimate.Add(678);
            calistaUltimate.Add(675);
            calistaUltimate.Add(748);
            calistaUltimate.Add(24);
            calistaUltimate.Add(747);
            calistaUltimate.Add(95);
            calistaUltimate.Add(385);
            calistaUltimate.Add(47);
            calistaUltimate.Add(312);
            calistaUltimate.Add(135);
            calistaUltimate.Add(182);
            calistaUltimate.Add(434);
            calistaUltimate.Add(80);
            calistaUltimate.Add(383);
            calistaUltimate.Add(37);
            calistaUltimate.Add(34);
            calistaUltimate.Add(740);
            calistaUltimate.Add(703);
            calistaUltimate.Add(57);
            calistaUltimate.Add(742);
            calistaUltimate.Add(901);
            calistaUltimate.Add(902);
            calistaUltimate.Add(903);
            calistaUltimate.Add(905);
            calistaUltimate.Add(193);
            calistaUltimate.Add(382);
            calistaUltimate.Add(683);
            calistaUltimate.Add(782);
            calistaUltimate.Add(784);

            //Lista Ultimateplus
            calistaUltimateplus.Add(106);
            calistaUltimateplus.Add(67);
            calistaUltimateplus.Add(766);
            calistaUltimateplus.Add(420);
            calistaUltimateplus.Add(215);
            calistaUltimateplus.Add(88);
            calistaUltimateplus.Add(757);
            calistaUltimateplus.Add(772);
            calistaUltimateplus.Add(118);
            calistaUltimateplus.Add(104);
            calistaUltimateplus.Add(105);
            calistaUltimateplus.Add(40);
            calistaUltimateplus.Add(435);
            calistaUltimateplus.Add(328);
            calistaUltimateplus.Add(776);
            calistaUltimateplus.Add(775);
            calistaUltimateplus.Add(777);
            calistaUltimateplus.Add(778);
            calistaUltimateplus.Add(779);
            calistaUltimateplus.Add(904);

        }
    }
}
