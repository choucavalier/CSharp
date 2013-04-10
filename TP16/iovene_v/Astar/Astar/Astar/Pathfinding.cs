using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Astar.MyLinkedList;

namespace Astar
{
    class Pathfinding
    {
        public static List<Node> PossibleNode = new List<Node>(); // Les noeuds possibles (cases adjacentes de tout le chemin)

        public static MyLinkedList<Tile> CalculatePathWithAStar(Map map, Tile startTile, Tile endTile)
        {
            PossibleNode.Clear();
            NodeList<Node> openList = new NodeList<Node>(); // Contiens tout les noeuds candidat (qui vont être examinés)
            NodeList<Node> closedList = new NodeList<Node>(); // Contiens la liste des meilleurs noeuds (le resultat du plus cours chemin)
            List<Node> possibleNodes; // cases adjacentes du noeud courant

            // Le noeud de départ
            Node startNode = new Node(startTile, null, endTile); // FIXME : on recupère le noeud de départ

            /**********************************/
            /* Traitement des noeuds candidat */
            /**********************************/

            openList.Add(startNode);

            while (openList.Count > 0) // Tant que la liste ouverte contient des éléments 
            {
                Node current = openList[0];
                openList.RemoveAt(0);
                closedList.Add(current);
                
                if (current.Tile == endTile) // si l'élément courant est la case destination
                {
                    MyLinkedList<Tile> solution = new MyLinkedList<Tile>();
                    // on reverse la liste fermée et on la retourne pour l'avoir dans le bonne ordre
                    while (current.Parent != null)
                    {
                        solution.AddFirst(current.Tile);
                        current = current.Parent;
                    }
                    return solution;
                }
                possibleNodes = current.GetPossibleNode(map, endTile); // FIXME : recupère la listes des cases adjacentes

                // on ajoute cette liste a notre variable static qui contient l'ensemble des listes adjacentes (gestion de l'affichage)
                PossibleNode.AddRange(possibleNodes) ;


                /***************************************/
                /* Ajout des noeuds adjacents candidat */
                /***************************************/
                for (int i = 0; i < possibleNodes.Count; i++) // on vérifie que chaque noeuds adjacent (possibleNodes)
                {
                    if (!closedList.Contains(possibleNodes[i])) // n'existe pas dans la liste fermée (eviter la redondance)
                    {
                        if (openList.Contains(possibleNodes[i])) // FIXME : Si il existe dans la liste ouverte on vérifie
                        {
                            if (possibleNodes[i].EstimatedMovement < openList[possibleNodes[i]].EstimatedMovement) // si le cout de deplacement du
                                // noeud est inferieur a un coût calculer précedement, dance cas la on remonte le chemin dans la liste ouverte
                                openList[possibleNodes[i]].Parent = current;
                        }
                        else
                            openList.DichotomicInsertion(possibleNodes[i]);                      
                    }
                }
            }
            return null;
        }
    }
}
