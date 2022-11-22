/*
Se dispone de una lista simplemente enlazada de clases SUELDO compuesta por el nombre de un jugador ( char NOM[20] ), el sueldo mensual ( int SUELDO )
y el puntero al siguiente jugador ( SUELDO * SIG ).

El puntero al inicio es un miembro privado de la clase CAMPEONATO de la forma SUELDO * INISUELDO.

También se dispone de una estructura tipo guirnalda compuesta por la clase EQUIPO, formada por el nombre del equipo ( char NOM[20]), el inicio de la lista de jugadores que integran ese equipo
(JUGADOR * PUNJU), y el puntero al siguiente equipo (EQUIPO * SIG ).

La clase JUGADOR esta formada simplemente por el nombre del jugador char NOM[20]), y el puntero al siguiente jugador (JUGADOR * SIG ).

El puntero al inicio de la guirnalda es un miembro privado de la clase CAMPEONATO de la forma EQUIPO * INIEQUIPO.

Se pide :

Dibujar la estructura descripta, con sus enlaces y nombres de campos y clases de nodos.
Construir la función void MILLONARIO( CAMPEONATO & ) que muestre en pantalla cual es el equipo que más gasta mensualmente en sueldos de jugadores y cuál es ese monto. */

#include <iostream>
#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include <time.h>

using namespace std;

class SUELDO
{
    private:
        SUELDO * INICIO;
    public:
        char NOM[20];
        int SUELDOTOTAL;
        SUELDO * SIG;

        SUELDO(char *);
};
SUELDO::SUELDO(char * S)
{
    int NUMERO;

    NUMERO = 100 + rand() % (950 - 150);

    strcpy(NOM, S);
    SIG = NULL;
    SUELDOTOTAL = NUMERO;
}
class JUGADOR
{
    public:
        char NOM[20];
        JUGADOR * SIG;
        JUGADOR(char *);
};
JUGADOR::JUGADOR(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
}
class EQUIPO
{
    public:
        char NOM[20];
        JUGADOR * PJUG;
        EQUIPO * SIG;
        EQUIPO(char *, JUGADOR *);
};
EQUIPO::EQUIPO(char * S, JUGADOR * J)
{
    strcpy(NOM, S);
    PJUG = J;
}
class CAMPEONATO
{
    private:
        SUELDO * INISUELDO;
        EQUIPO * INICIO;
        EQUIPO * BUSCAR(char *);
    public:
        CAMPEONATO();
        void CARGARCAMPEONATO(char *);
        void CARGARSUELDO(char *);
        void PONER(SUELDO *);
        void MIRAR();
        void friend MILLONARIO(CAMPEONATO &);
};
CAMPEONATO::CAMPEONATO()
{
    INICIO = NULL;
    INISUELDO = NULL;
}

void CAMPEONATO::CARGARSUELDO(char * S)
{
    SUELDO * P;

    P = new SUELDO(S);

    PONER(P);
}

void CAMPEONATO::PONER(SUELDO * NP)
{
    SUELDO * P;

    P = INISUELDO;
    NP->SIG = NULL;
    while(!INISUELDO)
    {
        INISUELDO = NP;
        return;
    }
    while(P->SIG)
    {
        P = P->SIG;
    }
    P->SIG = NP;
}

void CAMPEONATO::CARGARCAMPEONATO(char * S)
{
    char * GENERAEQUIPO();

    char BUF[20];

    JUGADOR * PJ, * P;
    EQUIPO * PE;

    PJ = new JUGADOR(S);

    strcpy(BUF, GENERAEQUIPO());
    PE = BUSCAR(BUF);

    if(!PE)
    {
        PE = new EQUIPO(BUF, PJ);

        PE->SIG = INICIO;
        INICIO = PE;

        return;
    }
    P = PE->PJUG;

    while(P->SIG)
    {
        P = P->SIG;
    }

    P->SIG = PJ;

}
EQUIPO * CAMPEONATO::BUSCAR(char * S)
{
    EQUIPO * PE;

    PE = INICIO;

    while(PE)
    {
        if(strcmpi(PE->NOM, S) == 0)
        {
            return PE;
        }
        PE = PE->SIG;
    }
    return NULL;
}
void CAMPEONATO::MIRAR()
{
    EQUIPO * PE;
    JUGADOR * PJ;

    PE = INICIO;
    while(PE)
    {
        cout << "\nEQUIPO: " << PE->NOM;

        PJ = PE->PJUG;
        while(PJ)
        {
            cout << "\nJUGADOR: " << PJ->NOM;

            PJ = PJ->SIG;
        }
        cout << "\n";
        PE = PE->SIG;
    }
}

void MILLONARIO(CAMPEONATO &C)
{
    int MAX = 0, AUXMAX = 0;
    char MAXEQUIPO[20];

    EQUIPO * PE;
    JUGADOR * PJ;
    SUELDO * PS;

    PE = C.INICIO;
    PS = C.INISUELDO;

    while(PE)
    {
        AUXMAX = 0;
        PJ = PE->PJUG;
        cout << "\nNOM EQUIPO: " << PE->NOM;
        while(PJ)
        {
            cout << "\nNOM JUGADOR: " << PJ->NOM;
            PS = C.INISUELDO;
            while(PS)
            {
                if(strcmpi(PS->NOM, PJ->NOM) == 0)
                {
                    cout << "\nNOM SUELDO: " << PS->NOM;
                    AUXMAX = AUXMAX + PS->SUELDOTOTAL;
                }
                PS = PS->SIG;
            }
            PJ = PJ->SIG;
        }
        if(AUXMAX > MAX)
        {
            strcpy(MAXEQUIPO, PE->NOM);
            MAX = AUXMAX;
        }

        cout << "\n AUXMAX: " << AUXMAX;
        PE = PE->SIG;
    }
    cout << "\nEL EQUIPO QUE MAS PAGA EN SUELDO ES " << MAXEQUIPO << " Y PAGA " << MAX;
}

char * GENERANOM();
char * GENERAEQUIPO();

int main()
{
    CAMPEONATO A;

    char NOMBRE[20];

    srand(65);

    strcpy(NOMBRE,GENERANOM());
    while(strcmpi(NOMBRE, "FIN") != 0)
    {
        A.CARGARCAMPEONATO(NOMBRE);
        A.CARGARSUELDO(NOMBRE);

        strcpy(NOMBRE,GENERANOM());
    }

    MILLONARIO(A);

    return 0;
}
char * GENERANOM()
{
	static int I = 0 ;
	static char NOM[][20] = {"DARIO","CAROLINA","PEPE","LOLA",
						     "PACO","LUIS","MARIA","ANSELMO",
						  	 "ANA","LAURA","PEDRO","ANIBAL",
						     "PABLO","ROMUALDO","ALICIA","MARTA",
						     "MARTIN","TOBIAS","SAUL","LORENA","LUIS",
							 "ANDRES","KEVIN","LUCRECIA","RAUL",
							 "ENZO","BETO","HERMINDO","FELIPE",
							 "GUILLERMO","FIN"};

	return NOM[I++] ;
}
char * GENERAEQUIPO()
{
	static char NOM[][20] = {"RIVER","RACING","SAN LORENZO",
                            "INDEPENDIENTE","BOCA"};
	return NOM[rand()%5] ;
}
