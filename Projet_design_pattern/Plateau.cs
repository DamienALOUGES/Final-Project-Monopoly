using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_design_pattern
{
    class Plateau // Singleton  

    {

            private static Plateau instance = null;
            private List<Case> plateau;

            private Plateau()

            {
                this.plateau = new List<Case>();

            }

            public static Plateau Instance

            {
                get

                {

                    if (instance == null)

                    {

                        instance = new Plateau();

                    }

                    return instance;

                }

            }
            

            public void AddCase(List<Case> plateau)
            { 
            
                 for (int i = 0; i < 40; i++)

                 {
                    if (i == 0)//start case

                    {
                         CaseChance chance = new CaseChance(i, "red", 200, true); //gagne 200 si on tombe dessus
                         plateau.Add(chance);
                    }

                    if (i > 0 && i < 10) //first row

                    {

                         CaseAchat achat = new CaseAchat(i, "blue", 450);
                         plateau.Add(achat);

                    }

                    if (i == 10)//prison case

                    {
    
                         CaseAutre jail = new CaseAutre(i, "black");
                         plateau.Add(jail);


                    }

                    if (i > 10 && i < 20)//second row

                    {

                         CaseAchat achat = new CaseAchat(i, "green", 600);
                         plateau.Add(achat);

                     }

                    if (i == 20)//chance case malus

                    {

                        CaseChance chance = new CaseChance(i, "red", 150, false); //perd 150  si on tombe dessus
                        plateau.Add(chance);

                    }

                    if (i > 20 && i < 30)//third row

                    {

                        CaseAchat achat = new CaseAchat(i, "yellow", 750);
                        plateau.Add(achat);
                    }

                    if (i == 30)//send to prison case

                    {

                        CaseAutre visitJail = new CaseAutre(i, "black");
                        plateau.Add(visitJail);
                    }

                    if (i > 30 && i <= 39)//fourth row

                    {

                        CaseAchat achat = new CaseAchat(i, "orange", 750);
                        plateau.Add(achat);

                     }



                  

                 }

            }



        }

    }


