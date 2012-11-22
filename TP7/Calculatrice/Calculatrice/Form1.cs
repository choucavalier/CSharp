using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculatrice
{
    public partial class Form1 : Form
    {
        const float pi = 3.1415926f;

        static float approx(float a, int b)
        {
            if (b < 0) throw new Exception("Must be positive or null");
            return b == 0 ? (float)(int)a : approx(a * 10, b - 1) / 10; // Le but ici est de faire passer avant la virgule b nombres situes apres la virgule, puis on cute l'entier et on redivise pour retourner au bon nombre de b apres la virgule. :)
        }

        // Le sujet nous oblige a faire de la recursion, alors oblige de faire ca... C'est beaucoup plus joli avec une boucle.
        static float my_sqrt(float a)
        {
            if (a >= 0)
                return my_sqrt(a, a / 2);
            else
                throw new Exception("Racine d'un nombre negatif");
        }

        // On passe en surcharge

        static float my_sqrt(float a, float b)
        {
            float x = (b + a / b) / 2;
            if (x != b)
                return my_sqrt(a, x);
            return x;
        }

        static float my_pow(float a, int b)
        {
            if (b < 0) return (1 / my_pow(a, -b)); // puissance negative -> on le transforme en puissance positive
            return (b == 0) ? 1 : (a * my_pow(a, b - 1)); // une recursion toute bete...
        }

        // Cette fonction teste si un entier est premier ou pas
        static bool is_prim(int x)
        {
            if (x % 2 == 0) // on elimine tous les entiers paires via une simple operation
                return false;
            for (int i = 3; i < x; i += 2) // ensuite on teste tous les entiers impaires via une boucle
            {
                if (x % i == 0)
                    return false;
            }
            return true; // on a toujours pas retrouve false, donc c'est que c'est ok.
        }

        static bool is_sexy(int a, int b)
        {
            if (a > 1000 || b > 1000 || !is_prim(a) || !is_prim(b)) return false; // Je gere d'abord tous les cas cons
            return (a - b == 6 || b - a == 6); // Je teste si la difference des deux fait 6
        }

        static int facto(int a)
        {
            return (a == 0) ? 1 : (a * facto(a - 1)); // obvious
        }

        static float deg_to_rad(float d)
        {
            return (d * (pi / 180)); // obvious
        }

        static float rad_to_deg(float r)
        {
            return (r * (180 / pi)); // obvious
        }

        /* Ceci etait une version plus jolie, mais qui n'etait pas recursive.
        
         * *****************
        static float my_cos(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2 * pi : 0);
            float b = 0;
            for (int i = 0; i < 6; i++)
            {
                b += (my_pow(-1, i) * my_pow(a, 2 * i)) / facto(2 * i);
            }
            return approx(b, 4);
        }
        */
        static float my_cos(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2 * pi : 0);
            // Un developpement limite se fait au plus proche possible de 0. Il faut donc modifier les angles qui sont trop grands, car ca fait des variables en radians un peu trop elevees.

            return my_cos(a, 5);
            // On va faire une surcharge de la fonction my_cos, juste parce qu'elle ne doit prendre qu'un seul parametre d'apres le sujet du TP...
        }

        static float my_cos(float a, int n)
        {
            float x = my_pow(-1, n) * my_pow(a, 2 * n) / facto(2 * n);
            // On defini Xn via la formule du tp

            return (n == 0) ? x : x + my_cos(a, n - 1);
            // si n = 0 on a fait 6 appels recursifs, donc on renvoit la valeur de X0, sinon on fait un appel recursif.
        }

        /* Idem que pour cos...
        static float my_sin(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2 * pi : 0);
            float b = 0;
            for (int i = 0; i < 6; i++)
            {
                b = b + (my_pow(-1, i) * my_pow(a, 2 * i + 1)) / facto(2 * i + 1);
            }
            return approx(b, 4);
        }
        */
        static float my_sin(float a)
        {
            a = (a + pi) % (2 * pi) - pi + ((a < 0) ? 2 * pi : 0);
            // Un developpement limite se fait au plus proche possible de 0. Il faut donc modifier les angles qui sont trop grands, car ca fait des variables en radians un peu trop elevees.

            return my_sin(a, 5);
            // On appelle notre fonction recursive que l'on va mettre en surcharge juste apres
        }

        static float my_sin(float a, int n)
        {
            float x = my_pow(-1, n) * my_pow(a, 2 * n + 1) / facto(2 * n + 1);
            // On defini Xn via la formule du developpement limite de sinus x au voisinage de 0

            return (n == 0) ? x : x + my_sin(a, n - 1);
            // si n = 0 on a fait 6 appels recursifs, donc on renvoit la valeur de X0, sinon on fait un appel 
        }

        static float my_tan(float a)
        {
            return my_sin(a) / my_cos(a);
            // tan = sin/cos , c'est pas un scoop. On aurait pu le faire recursivement mais pour tan c'est quand meme bien plus chiant car les nombres de Bernouilli rentrent en jeu dans la formule de son developpement limite.
        }

        // ******************* FORM *******************

        static float r; // Variable globale resultat

        public Form1()
        {
            InitializeComponent();
        }

        // Cette procedure est ma procedure d'initialisation de ma calculatrice. Elle n'est declenchee qu'une seule fois, au chargement du windows form.
        private void Form1_Load(object sender, EventArgs e)
        {
            calcBox.Focus(); // On focus sur notre champ de texte car on se doute que l'utilisateur va vouloir rentrer un nombre.
            r = 0; // Initialisation a r = 0, basique.

            // Alors la en fait j'ai 3 labels qui vont me permettre d'afficher a l'utilisateur ce qu'il fait ou a fait comme operation.
            // Donc la du coup je les place les uns a cotes des autres
            label1.Location = new Point(13,43);
            labelOp.Location = new Point(label1.Location.X + label1.Size.Width, 43);
            label2.Location = new Point(labelOp.Location.X + labelOp.Size.Width, 43);
        }

        // Voici les procedures du tp, dont je ne vais pas me servir puisque je code ma calculatrice pour qu'elle soit un minimum plus intuitive que ca...
        #region op_useless

        private void add(float a)
        {
            r += a;
        } // J'espere ne pas avoir besoin de vous expliquer

        private void sub(float a)
        {
            r -= a;
        } // J'espere ne pas avoir besoin de vous expliquer

        private void mul(float a)
        {
            r *= a;
        } // J'espere ne pas avoir besoin de vous expliquer

        private void div(float a)
        {
            r /= a;
        } // J'espere ne pas avoir besoin de vous expliquer

        private void mod(float a)
        {
            r %= a;
        } // J'espere ne pas avoir besoin de vous expliquer

        #endregion

        // Voici maintenant des procedures, demandees par le TP, mais qui cette fois trouvent leur utilite, etant donne que ce sont des operations unaires (voir la suite pour comprendre)
        // Ces fonctions ne font que modifier la valeur de r en lui appliquant la fonction
        #region op_cool
        private void cosOp(float a)
        {
            r = approx(my_cos(a),6);
        }

        private void sinOp(float a)
        {
            r = approx(my_sin(a),6);
        }

        private void tanOp(float a)
        {
            r = approx(my_tan(a),6);
        }

        private void sqrtOp(float a)
        {
            r = my_sqrt(a);
        }
        #endregion

        // Cette procedure affiche le nouveau resultat dans son champ de texte, vide le champ de texte de l'utilisateur et refocus celui ci dedans
        private void refresh()
        {
            resultBox.Text = r.ToString();
            calcBox.Text = "";
            calcBox.Focus();
        }

        // apres une operation, les textes des labels changent, je dois donc les repositionner par rapport a leur nouvelle largeur. Etant donne le nombre de fois ou j'effectue ces operations, je me devais d'en faire une fonction
        private void rePose()
        {
            label1.Location = new Point(13, 43);
            labelOp.Location = new Point(label1.Location.X + label1.Size.Width, 43);
            label2.Location = new Point(labelOp.Location.X + labelOp.Size.Width, 43);
        }
        // J'aurais pu combiner ces deux dernieres procedures mais bon... Je trouve ca plus clair comme ca.


        // Cette fonction est declenchee lorsque l'utilisateur clique sur un bouton d'operation binaire
        // Dans ma calculette, le clique sur les boutons des operations binaires ne produit aucun changement de ma variable globale resultat sauf dans le cas ou on veut effectuer plusieurs operations a la suite directement sans passer par le bouton egal.
        private void goAhead(Button b)
        {
            if (label1.Text != "" && label2.Text == "")
            {
                label1.Text = eval(float.Parse(label1.Text), labelOp.Text, float.Parse(calcBox.Text)).ToString();
            }

            else
            {
                if (calcBox.Text == "")
                {
                    label1.Text = r.ToString();
                    // le champ utilisateur est vide, donc je remplace le premier nombre de mes labels par r, car l'utilisateur veut effectuer une operation sur le r actuel.
                }

                else
                {
                    label1.Text = calcBox.Text;
                    // sinon c'est qu'il veut effectuer une operation sur le nombre qu'il vient d'entrer
                }
            }

            labelOp.Text = b.Text;
            label2.Text = "";

            rePose();
            refresh();
        }

        // Les fonctions qui suivent sont justes des appels aux vraies fonctions lorsque l'utilisateur clique sur un bouton

        // Operations binaires
        #region op_bin
        private void addButton_Click(object sender, EventArgs e)
        {
            goAhead(addButton);
            refresh();
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            goAhead(subButton);
            refresh();
        }

        private void mulButton_Click(object sender, EventArgs e)
        {
            goAhead(mulButton);
            refresh();
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            goAhead(divButton);
            refresh();
        }

        private void modButton_Click(object sender, EventArgs e)
        {
            goAhead(modButton);
            refresh();
        }

        private void powButton_Click(object sender, EventArgs e)
        {
            goAhead(powButton);
        }

        #endregion

        // Operations unaires
        #region op_un
        private void cosButton_Click(object sender, EventArgs e)
        {
            // Je gere si l'utilisateur est en radians ou en degres, et s'il veut faire l'operation sur le resultat actuel ou sur un nombre envoye en parametre
            if (calcBox.Text == "")
                if (degreeButton.Checked == true)
                    cosOp(deg_to_rad(r));
                else
                    cosOp(r);
            else
                if (degreeButton.Checked == true)
                    cosOp(deg_to_rad(float.Parse(calcBox.Text)));
                else
                    cosOp(float.Parse(calcBox.Text));
            refresh();
        }

        private void sinButton_Click(object sender, EventArgs e)
        {
            // Idem que pour cos
            if (calcBox.Text == "")
                if (degreeButton.Checked == true)
                    sinOp(deg_to_rad(r));
                else
                    sinOp(r);
            else
                if (degreeButton.Checked == true)
                    sinOp(deg_to_rad(float.Parse(calcBox.Text)));
                else
                    sinOp(float.Parse(calcBox.Text));
            refresh();
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            // Idem
            if (calcBox.Text == "")
                if (degreeButton.Checked == true)
                    tanOp(deg_to_rad(r));
                else
                    tanOp(r);
            else
                if (degreeButton.Checked == true)
                    tanOp(deg_to_rad(float.Parse(calcBox.Text)));
                else
                    tanOp(float.Parse(calcBox.Text));
            refresh();
        }

        private void sqrtButton_Click(object sender, EventArgs e)
        {
            // Idem
            if (calcBox.Text == "")
                sqrtOp(r);
            else
                sqrtOp(float.Parse(calcBox.Text));
            refresh();
        }
        #endregion

        /* ----------------------------------------------- */

        // Voila ma fonction d'evaluation, elle me permet de retourner la valeur de toutes mes operations binaires appliquees a deux float.

        private float eval(float a, string o, float b)
        {
            switch (o)
            {
                case "+":
                    return a + b;
                case "−":
                case "-":
                    return a - b;
                case "×":
                case "*":
                    return a * b;
                case "÷":
                case "/":
                    if (b == 0)
                        throw new Exception("Division par zero");
                    else
                        return a / b;
                case "%":
                case "mod":
                    if (b == 0)
                        throw new Exception("Division par zero");
                    else
                        return a % b;
                case "^":
                    if (a == 0 && b == 0)
                        throw new Exception("0^0 ne se calcule pas");
                    else
                        return my_pow(a, (int)b);
                default:
                    return 0;
            }
        }

        // Fonction qui gere un peu tout au final, elle va changer la valeur de r a chaque fois (normal c'est le bouton " = ". Et elle gere tous les cas : en fonction des champs/labels vides ou ramplis, je sais ce que l'utilisateur veut faire. C'est du cas par cas.

        private void equalButton_Click(object sender, EventArgs e)
        {
            float f;
            if (!float.TryParse(calcBox.Text, out f))
            {
                if (calcBox.Text == "")
                {
                    r = 0; label1.Text = "";
                    label2.Text = "";
                    labelOp.Text = "";
                    refresh();
                    rePose();
                    return;
                }

                else
                    throw new Exception("Entrez un nombre.");
            };

            if (label1.Text == "" || (label1.Text != "" && label2.Text != "" && labelOp.Text != "" && calcBox.Text != ""))
            {
                r = float.Parse(calcBox.Text);
                label1.Text = calcBox.Text;
                labelOp.Text = "=";
                label2.Text = calcBox.Text;
            }
            else
            {
                if (label1.Text != "" && label2.Text != "" && labelOp.Text != "" && calcBox.Text == "")
                {
                    label1.Text = r.ToString();
                    r = eval(r, labelOp.Text, float.Parse(label2.Text));
                }

                else
                {
                    r = eval(float.Parse(label1.Text), labelOp.Text, float.Parse(calcBox.Text));
                    label2.Text = calcBox.Text;
                }
            }
            rePose();
            refresh();
        }

        private void calcBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '+')
                addButton_Click(null, null);

            if (e.KeyChar == '-' || e.KeyChar == '−')
                subButton_Click(null, null);

            if (e.KeyChar == '/' || e.KeyChar == '÷')
                divButton_Click(null, null);

            if (e.KeyChar == '*' || e.KeyChar == '×')
                mulButton_Click(null, null);

            if (e.KeyChar == '%')
                modButton_Click(null, null);

            if (e.KeyChar == '^')
                powButton_Click(null, null);

            if (e.KeyChar == (char)13)
                equalButton_Click(null, null);
        }

        private bool testOp(char c)
        {
            List<char> ops = new List<char> { '+', '-', '−', '/', '÷', '*', '×', '%', '^' };
            if (ops.Contains(c))
                return true;
            else
                return false;
        }

        private void calcBox_TextChanged(object sender, EventArgs e)
        {
            if (calcBox.Text.Length == 0)
                return;
            if (testOp(calcBox.Text[calcBox.Text.Length - 1]))
                calcBox.Text = "";
        }
    }
}
