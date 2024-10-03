using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IK : MonoBehaviour
{
    // Le transform (noeud) racine de l'arbre, 
    // le constructeur créera une sphère sur ce point pour en garder une copie visuelle.
    public GameObject rootNode = null;         
    
    // Un transform (noeud) (probablement une feuille) qui devra arriver sur targetNode
    public Transform srcNode = null;
    public List<Transform> srcNodeList = new List<Transform>();          

    
    // Le transform (noeud) cible pour srcNode
    public Transform targetNode = null;                         
    public Transform targetNode1 = null;                         

    // Si vrai, recréer toutes les chaines dans Update
    public bool createChains = true;                            
    
    // Toutes les chaines cinématiques 
    public List<IKChain> chains = new List<IKChain>();          

    // Nombre d'itération de l'algo à chaque appel
    public int nb_ite = 10;                                     


    void Start()
    {
        if (createChains)
        {
            Debug.Log("(Re)Create CHAIN");
            //createChains = false;    // la chaîne est créée une seule fois, au début

            // TODO :   
            // Création des chaînes : une chaîne cinématique est un chemin entre deux nœuds carrefours.
            // Dans la 1ere question, une unique chaine sera suffisante entre srcNode et rootNode.
            //chains.Insert(0,new IKChain(rootNode.transform,srcNode,rootNode.transform,targetNode));


                int nb_chaine = 0;
                int nb_target = 0;
                Transform root = null;

                foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>()){
                    if( tr.childCount > 1){
                        
                        chains.Insert(nb_chaine,new IKChain(rootNode.transform, tr, rootNode.transform, null));
                        root = tr;
                        nb_chaine ++;
                    // je suis un root et un source node
                   }
                   else if( tr.childCount == 0){
                        
                        if(nb_target == 0){
                            chains.Insert(nb_chaine,new IKChain(root,tr,null,targetNode.transform));
                        }
                        else{
                            chains.Insert(nb_chaine,new IKChain(root,tr,null,targetNode1.transform));
                        }
                        
                        nb_chaine++;
                        nb_target++;
                    // je suis un source node
                   }


                }

            for(int i=0; i < chains.Count; i++){
                for(int j=0; j < chains.Count; j++){
                    if(i != j){
                        for(int k=0; k < chains[j].joints.Count; k++){
                            chains[i].Merge(chains[j].joints[k]);
                        }
                    }
                }
            }

            // TODO-2 : Pour parcourir tous les transform d'un arbre d'Unity vous pouvez faire une fonction récursive
            // ou utiliser GetComponentInChildren comme ceci :
            // foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>())

            
            // TODO-2 : Dans le cas où il y a plusieurs chaines, fusionne les IKJoint entre chaque articulation.
        }
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.I))
        {
            IKOneStep(true);
        }
                    IKOneStep(true);

        
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Chains count="+chains.Count);
            foreach (IKChain ch in chains)
                ch.Check();
        }
    }


    void IKOneStep(bool down)
    {

        for (int j = 0; j < nb_ite; ++j)
        {
            // TODO : IK Backward (remontée), appeler la fonction Backward de IKChain 
            // sur toutes les chaines cinématiques.
            chains.Reverse();

            foreach (IKChain ch in chains)
            {
                Debug.Log("je suis bcp ="+ ch.joints[2].name);
                ch.Backward();
                // ch.ToTransform();
            }
            foreach (IKChain ch in chains)
            {
                ch.ToTransform();
            }
            chains.Reverse();

            foreach (IKChain ch in chains)
            {
                ch.Forward();
            }

            foreach (IKChain ch in chains)
            {
                ch.ToTransform();
            }


            // TODO : appliquer les positions des IKJoint aux transform en appelant ToTransform de IKChain

            // IK Forward (descente), appeler la fonction Forward de IKChain 
            // sur toutes les chaines cinématiques.

            // TODO : appliquer les positions des IKJoint aux transform en appelant ToTransform de IKChain


                      
            
        }



    }


}