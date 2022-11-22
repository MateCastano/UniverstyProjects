#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <iostream>

using namespace std ;

class Visitante
{
	public:
        Visitante(char *);
        char NOM [20];
        Visitante * SIG;
};

Visitante::Visitante(char * N)
{
    strcpy(NOM, N);
    SIG = NULL;
}

class Museo
{
	public:
        char NOM [20];
        Visitante * PVIS;
        Museo * SIG;
        Museo(char *);
};

Museo::Museo(char * M)
{
    strcpy(NOM, M);
    SIG = NULL;
    PVIS = NULL;
}

class RegistroVisitas
{
	public:
        RegistroVisitas();
        Museo * INICIO;
        void nuevoMuseo(char *);
        void registrarVisita(char * , char *);
        void verVisitantesPerfectos();
        void borrarMuseosMenosVisitados();
        void eliminar(Museo *);
        void mirar();
};

RegistroVisitas::RegistroVisitas()
{
    INICIO = NULL;
}

void RegistroVisitas::nuevoMuseo(char * M)
{
    Museo * PM;

    PM = new Museo(M);

    PM->SIG = INICIO;
    INICIO = PM;
}

void RegistroVisitas::registrarVisita(char * M, char * N)
{
    Visitante * PV;
    Museo * PM;

    PV = new Visitante(N);

    PM = INICIO;

    while(PM)
    {
        if(strcmpi(PM->NOM, M) == 0)
        {
             PV->SIG = PM->PVIS;
             PM->PVIS = PV;
             return;
        }
        PM = PM->SIG;
    }
}

void RegistroVisitas::verVisitantesPerfectos()
{
    Museo * PM;
    Visitante * PV;
    int cont = 0;

    PM = INICIO;

    cout << "\nMUSEOS CON ASISTENCIA PERFECTA";

    while(PM)
    {
        PV = PM->PVIS;
        cont = 0;
        while(PV)
        {
            cont ++;
            PV = PV->SIG;
        }
        if(cont == 3)
        {
            cout << "\n" << PM->NOM;
        }
        PM = PM->SIG;
    }
}

void RegistroVisitas::mirar()
{
    Museo * PM;
    Visitante * PV;

    cout << "\n";
    cout << "\nMUSEOS: ";

    PM = INICIO;
    while(PM)
    {
        cout << "\nMUSEO: " << PM->NOM;
        PV = PM->PVIS;
        while(PV)
        {
            cout << "\nVISITANTE: " << PV->NOM;
            PV = PV->SIG;
        }
        cout << "\n";
        PM = PM->SIG;
    }
}

void RegistroVisitas::borrarMuseosMenosVisitados()
{
    Museo * PM;
    Visitante * PV;
    char museoBorrar[20];
    int cont = 0, MIN = 0, inicilizador = 1;

    PM = INICIO;
    while(PM)
    {
        PV = PM->PVIS;
        cont = 0;
        while(PV)
        {
           cont ++;
           PV = PV->SIG;
        }
        if(inicilizador == 1)
        {
            MIN = cont;
            inicilizador = 0;
        }
        if(cont < MIN)
        {
            MIN = cont;
            strcpy(museoBorrar, PM->NOM);
        }
        PM = PM->SIG;
    }

    PM = INICIO;

    while(PM)
    {
        if(strcmpi(PM->NOM, museoBorrar) == 0)
        {
            eliminar(PM);
            return;
        }
        PM = PM->SIG;
    }
}

void RegistroVisitas::eliminar(Museo * PELIM)
{
    Museo * PM;

    PM = INICIO;

    if(INICIO == PELIM)
    {
        INICIO = PELIM->SIG;
        delete PELIM;
        return;
    }
    while(PM && PM->SIG != PELIM)
    {
        PM = PM->SIG;
    }
    if(PM)
    {
        PM->SIG = PM->SIG->SIG;
        delete PELIM;
    }
}

int main()
{
	RegistroVisitas * lista = new RegistroVisitas;

    	lista->nuevoMuseo("MALBA");
	lista->nuevoMuseo("MUSEO HISTORICO NAC.");
	lista->nuevoMuseo("MUSEO DE CS. NATURALES");

	lista->registrarVisita("MALBA", "Pepe");
	lista->registrarVisita("MUSEO HISTORICO NAC.", "Pepe");
	lista->registrarVisita("MALBA", "Maria Alvarez");
	lista->registrarVisita("MUSEO DE CS. NATURALES", "Pepe");
	lista->registrarVisita("MUSEO DE CS. NATURALES", "Roberto Sanchez");
	lista->registrarVisita("MUSEO DE CS. NATURALES", "Maria Alvarez");

	lista->mirar();

	lista->verVisitantesPerfectos();
	lista->borrarMuseosMenosVisitados(); //borra el historico nacional

	lista->mirar();

return 0;
}
