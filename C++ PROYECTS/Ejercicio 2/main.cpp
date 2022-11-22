/*
La clase LISTA1 esta formada por un puntero a la clase NODO (privado) y las funciones asociadas.
La clase NODO esta compuesta por los miembros públicos NOM (string de 20) y el puntero SIG (NODO *), más las funciones asociadas.
La lista contiene nombres que no guardan ningún orden y aparecen repetidos correspondiendo cada nodo a un voto en un certamen de popularidad.

La clase LISTA2 esta formada por un puntero a la clase CANDIDATO (privado) y las funciones asociadas.
La clase CANDIDATO esta compuesta por los miembros públicos NOM (string de 20), CANT(int) y el puntero SIG (CANDIDATO *), más las funciones asociadas.
La lista2 contiene nombres (que no se repiten) y la cantidad de votos recibidos .


Se pide construir la función void AGREGA(LISTA1& , LISTA2&), tal que agregue a LISTA2 los votos de LISTA1. Cada NODO que reciba incrementará 1 voto en el NODO2 correspondiente,
o darlo de alta en caso de no existir ese nombre en LISTA2.
Indicar que característica debe tener la función AGREGA() para acceder a ambas listas.*/

#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

using namespace std;

class LISTA2;

//NODO
class NODO
{
    public:
        char NOM[20];
        NODO * SIG;

        NODO(char *);
};

NODO::NODO(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
}

//CANDIDATO
class CANDIDATO
{
    public:
        char NOM[20];
        int CANT;
        CANDIDATO * SIG;

        CANDIDATO(char *, int);
};

CANDIDATO::CANDIDATO(char * S, int C)
{
    strcpy(NOM, S);
    SIG = NULL;
    CANT = C;
}

//LISTA 1
class LISTA1
{
    private:
        NODO * INICIONODOS;
    public:
        LISTA1();
        void CARGARVOTOS(char * );
        void PONER(NODO * );
        void friend AGREGAR(LISTA1 &, LISTA2 &);
        void MIRAR();
};

//LISTA 2
class LISTA2
{
    private:
        CANDIDATO * INICIOCANDIDATO;
    public:
        LISTA2();
        void friend AGREGAR(LISTA1 &, LISTA2 &);
        void friend MIRAR2(LISTA2 &);
};

LISTA1::LISTA1()
{
    INICIONODOS = NULL;
}

LISTA2::LISTA2()
{
    INICIOCANDIDATO = NULL;
}

void LISTA1::CARGARVOTOS(char * S)
{
    NODO * P;

    P = new NODO(S);

    PONER(P);
}

void LISTA1::PONER(NODO * NP)
{
    NODO * P;

    P = INICIONODOS;
    NP->SIG = NULL;

    while(!INICIONODOS)
    {
        INICIONODOS = NP;
        return;
    }

    while(P->SIG)
    {
        P = P->SIG;
    }

    P->SIG = NP;
}

//FUNCION AGREGAR
void AGREGAR(LISTA1 &L1, LISTA2 &L2)
{
    NODO * P1, * AUX;
    CANDIDATO * NUEVO;
    char NOMBRE[20];
    int CANTIDAD = 0;

    P1 = L1.INICIONODOS;

    strcpy(NOMBRE ,P1->NOM);

    while(P1)
    {
        if(strcmpi(NOMBRE, P1->NOM) == 0)
        {
            CANTIDAD ++;
        }
        P1 = P1->SIG;
    }

    NUEVO = new CANDIDATO(NOMBRE, CANTIDAD);
    L2.INICIOCANDIDATO = NUEVO;
    NUEVO->SIG = NULL;

    P1 = L1.INICIONODOS->SIG;

    while(P1)
    {
        CANTIDAD = 0;
        strcpy(NOMBRE, P1->NOM);
        while(NUEVO)
        {
            if(strcmpi(P1->NOM, NUEVO->NOM) == 0)
            {
                if(P1->SIG == NULL)
                {
                    return;
                }
                P1 = P1->SIG;
                strcpy(NOMBRE, P1->NOM);
                NUEVO = L2.INICIOCANDIDATO;
            }
            else
            {
                NUEVO = NUEVO->SIG;
            }
        }
        AUX = L1.INICIONODOS;
        while(AUX)
        {
            if(strcmpi(AUX->NOM, NOMBRE)==0)
            {
                CANTIDAD ++;
            }
            AUX = AUX->SIG;
        }
        NUEVO = new CANDIDATO(NOMBRE, CANTIDAD);
        NUEVO->SIG = L2.INICIOCANDIDATO;
        L2.INICIOCANDIDATO = NUEVO;

        P1 = P1->SIG;
    }
}
//MIRAR
void LISTA1::MIRAR()
{
    NODO * P;

    P = INICIONODOS;

    cout << "\nLISTA 1\n";
    while(P)
    {
        if(strcmpi(P->NOM, "FIN") != 0)
        {
            cout << "\nNOM: " << P->NOM;
        }
        P = P->SIG;
    }
}

//MIRAR2
void MIRAR2(LISTA2 &L2)
{
    CANDIDATO * P;

    P = L2.INICIOCANDIDATO;

    cout << "\nLISTA 2\n";
    while(P)
    {
        if(strcmpi(P->NOM, "FIN") != 0)
        {
            cout << "\nNOM: " << P->NOM;
            cout << "\nVOTOS: " << P->CANT;
        }
        P = P->SIG;
    }
    cout << "\n";
}

//MAIN
int main()
{
    LISTA1 A;
    LISTA2 B;
    char NOMBRE[20] = "";

    while(strcmpi(NOMBRE,"FIN"))
    {
        cout << "INGRESE NOMBRE DEL VOTO: ";
        cin >> NOMBRE;

        A.CARGARVOTOS(NOMBRE);
    }

    A.MIRAR();
    AGREGAR(A, B);
    MIRAR2(B);

    return 0;
}
