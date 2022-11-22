/*Se recibirá el voto del público para determinar quienes fueron las 10 personalidades del año.

Los nombres de los candidatos se recibirán hasta que se ingrese palabra “FIN”.
Cada nombre recibido equivale a un voto.
Si el candidato votado no existe en la lista , se lo debe dar de alta y contabilizar el voto.
Si existe, se debe actualizar la cantidad de votos que tiene.
(En este caso NO se debe crear un nuevo nodo).

Determinar el ganador (considerándolo único) y sus votos.*/

#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

using namespace std;

class VOTO
{
    public:
        char NOMVOT[20];
        VOTO * SIGUIENTE;
        int VOTOS = 0;

        VOTO(char *);
};

VOTO::VOTO(char * NOM)
{
    strcpy(NOMVOT, NOM);
    SIGUIENTE = NULL;
}

class LISTA
{
public:
    VOTO * INICIO;
    char NOMCAND[20];
    void MIRAR();
    void AGREGAR(char *);
    void PONER(VOTO *);
    void MAYOR();

    LISTA();
    ~LISTA();
};

LISTA::LISTA()
{
    INICIO = NULL;
}
LISTA::~LISTA()
{
    VOTO * P;

    P = INICIO;
    INICIO = NULL;

    while(P)
    {
        delete P;

        P = P->SIGUIENTE;
    }
}

void LISTA::MIRAR()
{
    VOTO * AUX;

    AUX = INICIO;

    while(AUX)
    {
        if(strcmpi(AUX->NOMVOT, "FIN") != 0)
        {
            cout << "\nNOM: " << AUX->NOMVOT << "\n";
            cout << "\VOTOS: " << AUX->VOTOS << "\n";
        }

        AUX = AUX->SIGUIENTE;
    }
}

void LISTA::AGREGAR(char * S)
{
    VOTO * P;

    P = new VOTO(S);

    PONER(P);
}

void LISTA::PONER(VOTO * NP)
{
    VOTO * P;

    P = INICIO;
    NP->SIGUIENTE = NULL;

    if(!INICIO)
    {
        cout << "\nENTRO LISTA VACIA\n";
        INICIO = NP;
        return;
    }
    while(P->SIGUIENTE)
    {
        P = P->SIGUIENTE;
    }

    cout << "\nENTRO LISTA\n";
    P->SIGUIENTE = NP;
}

void LISTA::MAYOR()
{
    VOTO * P, * PRECORRER;
    int CONT = 0, CONTMAYOR = 0;
    char NOMBRE[20] = "", NOMBREMAYOR[20] = "";

    P = INICIO;
    PRECORRER = INICIO;

    while(P)
    {
        CONT = 0;
        if(strcmpi(P->NOMVOT, NOMBRE) != 0)
        {
            strcpy(NOMBRE,P->NOMVOT);
        }

        PRECORRER = INICIO;
        while(PRECORRER)
        {
            if(strcmpi(PRECORRER->NOMVOT, NOMBRE) == 0)
            {
                CONT ++;
                P->VOTOS ++;
            }

            PRECORRER = PRECORRER->SIGUIENTE;
        }
        if(CONT > CONTMAYOR)
        {
            CONTMAYOR = CONT;
            strcpy(NOMBREMAYOR, NOMBRE);
        }
        P = P->SIGUIENTE;
    }

    cout << "\nEL CANDIDATO CON MAS VOTOS ES: " << NOMBREMAYOR << " Y LA CANTIDAD DE VOTOS QUE RECIBIO FUE DE: " << CONTMAYOR;
}

int main()
{
    LISTA A;
    char NOMBRE[20] = "";

    while(strcmpi(NOMBRE,"FIN"))
    {
        cout << "INGRESE NOMBBRE DEL VOTO: ";
        cin >> NOMBRE;
        A.AGREGAR(NOMBRE);
    }

    A.MAYOR();

    cout << "\n";

    A.MIRAR();

    return 0;
}
