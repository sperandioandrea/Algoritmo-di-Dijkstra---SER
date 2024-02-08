using System;

class Dijkstra
{
    private const int Infinito = int.MaxValue;

    static int[] AlgoritmoDiDijkstra(int[,] grafo, int sorgente)
    {
        int numNodi = grafo.GetLength(0);
        int[] distanza = new int[numNodi];
        bool[] visitato = new bool[numNodi];

        for (int i = 0; i < numNodi; i++)
        {
            distanza[i] = Infinito;
            visitato[i] = false;
        }

        distanza[sorgente] = 0;

        for (int count = 0; count < numNodi - 1; count++)
        {
            int minDistanza = Infinito;
            int minIndice = -1;

            for (int v = 0; v < numNodi; v++)
            {
                if (!visitato[v] && distanza[v] <= minDistanza)
                {
                    minDistanza = distanza[v];
                    minIndice = v;
                }
            }

            int u = minIndice;
            visitato[u] = true;

            for (int v = 0; v < numNodi; v++)
            {
                if (!visitato[v] && grafo[u, v] != 0 && distanza[u] != Infinito && distanza[u] + grafo[u, v] < distanza[v])
                {
                    distanza[v] = distanza[u] + grafo[u, v];
                }
            }
        }

        return distanza;
    }

    static void Main()
    {
        int[,] grafo = {
            {0, 4, 0, 0, 0, 0, 0, 8, 0},
            {4, 0, 8, 0, 0, 0, 0, 11, 0},
            {0, 8, 0, 7, 0, 4, 0, 0, 2},
            {0, 0, 7, 0, 9, 14, 0, 0, 0},
            {0, 0, 0, 9, 0, 10, 0, 0, 0},
            {0, 0, 4, 14, 10, 0, 2, 0, 0},
            {0, 0, 0, 0, 0, 2, 0, 1, 6},
            {8, 11, 0, 0, 0, 0, 1, 0, 7},
            {0, 0, 2, 0, 0, 0, 6, 7, 0}
        };

        int sorgente = 0;
        int[] distanze = AlgoritmoDiDijkstra(grafo, sorgente);

        for (int i = 0; i < distanze.Length; i++)
        {
            Console.WriteLine($"Distanza più breve da nodo {sorgente} a nodo {i} è {distanze[i]}");
        }
    }
}
