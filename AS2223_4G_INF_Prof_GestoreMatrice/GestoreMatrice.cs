using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AS2223_4G_INF_Prof_GestoreMatrice
{
    /// <summary>
    /// Gestore di una matrice quadrata
    /// </summary>
    public class GestoreMatrice
    {
        // definizione e istanziazione matrice in base alle dimensioni indicate dall'utente
        int[,] mat;

        // dimensione della matrice
        int matSize;

        /// <summary>
        /// Istanzia una matrice quadra di dimensione lato
        /// </summary>
        /// <param name="lato"></param>
        public GestoreMatrice(int lato)
        {
            // istanzia la matrice secondo le dimensioni dell'utente
            mat = new int[lato, lato];

            // mi salvo la larghezza della matrice
            matSize = lato;
        }

        /// <summary>
        /// Istanzia e carica la matrice con la matrice passata come parametro
        /// </summary>
        /// <param name="mat"></param>
        public GestoreMatrice(int[,] mat)
        {
            // istanzia la matrice secondo le dimensioni dell'utente
            this.mat = mat;

            // mi salvo la larghezza della matrice
            matSize = mat.GetUpperBound(0) + 1;
        }

        /// <summary>
        /// Carica la matrice con valori casuali fra minValue e MaxValue
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public void CaricaMatrice(int minValue, int maxValue)
        {
            // dichiara e istanzia il generatore di numeri casuali
            Random rnd = new Random();

            // scorri tutti gli elementi della matrice
            for (int r = 0; r < matSize; r++)
            {
                for (int c = 0; c < matSize; c++)
                {
                    mat[r, c] = rnd.Next(minValue, maxValue + 1);
                }
            }
        }

        /// <summary>
        /// Stampa la matrice nella console opportunamente formattata
        /// </summary>
        public void StampaMatrice()
        {
            // scorri tutti gli elementi della matrice
            for (int r = 0; r < matSize; r++)
            {
                for (int c = 0; c < matSize; c++)
                {
                    Console.Write(mat[r, c].ToString().PadLeft(4) + " ");
                }

                // vai a capo a fine riga
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Stampa la cornice della matrice da [0,0] per righe distinte in senso antiorario
        /// </summary>
        public void StampaCornice()
        {
            Console.WriteLine("lato sx");
            for (int i = 0; i < matSize; i++)
                Console.WriteLine(mat[i, 0]);

            Console.WriteLine("lato inferiore senza il vertice in basso a sx");
            for (int i = 1; i < matSize; i++)
                Console.WriteLine(mat[matSize - 1, i]);

            Console.WriteLine("lato dx senza il vertice in basso a dx");
            for (int i = (matSize - 1) - 1; i >= 0; i--)
                Console.WriteLine(mat[i, matSize - 1]);

            Console.WriteLine("lato superiore senza vertice in alto a dx e a sx");
            for (int i = (matSize - 1) - 1; i >= 1; i--)
                Console.WriteLine(mat[0, i]);
        }

        /// <summary>
        /// Inverte i valori della prima colonna della matrice con l'ultima
        /// </summary>
        /// <returns></returns>
        public void InvertiPrimaUltimaColonna()
        {
            int temp;

            // scorri tutti gli elementi della matrice
            for (int r = 0; r < matSize; r++)
            {
                temp = mat[r, 0];
                mat[r, 0] = mat[r, matSize - 1];
                mat[r, matSize - 1] = temp;
            }
        }

        /// <summary>
        /// Cerca il valore passato nella matrice e restituisce il numero di occorrenze
        /// </summary>
        /// <param name="valoreDaCercare"></param>
        /// <returns></returns>
        public int ContaValore(int valoreDaCercare)
        {
            int nValori = 0;

            // scorri tutti gli elementi della matrice
            for (int r = 0; r < matSize; r++)
            {
                for (int c = 0; c < matSize; c++)
                {
                    if (mat[r, c] == valoreDaCercare)
                        nValori += 1;
                }

            }
            return nValori;
        }

        /// <summary>
        /// Calcola il valore minimo, massimo e medio (ritornato) dei valori inseriti nella matrice
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public double CalcolaMinMaxMedio(ref int min, ref int max)
        {
            int mat_size = mat.GetUpperBound(0) + 1;
            double medio;

            min = mat[0, 0];
            max = mat[0, 0];

            medio = 0;
            // scorri tutti gli elementi della matrice
            for (int r = 0; r < mat_size; r++)
            {
                for (int c = 0; c < mat_size; c++)
                {
                    medio += mat[r, c];

                    if (mat[r, c] > max)
                        max = mat[r, c];

                    if (mat[r, c] < min)
                        min = mat[r, c];
                }
            }

            medio = medio / (mat_size * mat_size);

            return medio;
        }

        /// <summary>
        /// Ritorna il valore della matrice in una cella
        /// </summary>
        /// <param name="riga"></param>
        /// <param name="colonna"></param>
        /// <returns></returns>
        public int GetValue(int riga, int colonna)
        {
            return mat[riga, colonna];
        }

    }
}
