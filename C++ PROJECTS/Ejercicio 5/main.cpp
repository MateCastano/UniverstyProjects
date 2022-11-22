#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <iostream>

using namespace std;

class LISTA_DE_PRECIOS;
class COMPONENTE_QUIMICO;
class LABORATORIO;

class COMPONENTE
{
    public :
        COMPONENTE(char *);
        char NOM[20] ;
        COMPONENTE * SIG ;
        int BUSCAR(LISTA_DE_PRECIOS &);
};

COMPONENTE::COMPONENTE(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
}

class DOLENCIA
{
    public :
        DOLENCIA(char *);
        char NOM[20] ;
        DOLENCIA * SIG ;
};

DOLENCIA::DOLENCIA(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
}

class MEDICINA
{
    public :
        MEDICINA(char * S);
        char NOM[20] ;
        COMPONENTE * PCOM ;
        DOLENCIA * PDOL ;
        MEDICINA * SIG ;
};

MEDICINA::MEDICINA(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
    PDOL = NULL;
    PCOM = NULL;
}

class LISTA_DE_PRECIOS;

class VADEMECUM
{
    private :
        MEDICINA * ORIGEN ;
    public :
        VADEMECUM();
        void CARGARMEDICAMENTO(char *);
        void CARGARCOMPONENTE(char *, char *);
        void CARGARDOLENCIA(char *, char *);
        int CHEAPER(char *, LISTA_DE_PRECIOS &);
        void MIRAR();
};

VADEMECUM::VADEMECUM()
{
    ORIGEN = NULL;
}

void VADEMECUM::CARGARMEDICAMENTO(char * S)
{
    MEDICINA * P;

    P = new MEDICINA(S);

    P->SIG = ORIGEN;
    ORIGEN = P;
}

void VADEMECUM::CARGARCOMPONENTE(char * M, char * C)
{
    COMPONENTE * NC;
    MEDICINA * PM;

    PM = ORIGEN;

    NC = new COMPONENTE(C);
    while(PM)
    {
        if(strcmpi(PM->NOM, M) == 0)
        {
            NC->SIG = PM->PCOM;
            PM->PCOM = NC;
            return;
        }
        PM = PM->SIG;
    }
}

void VADEMECUM::CARGARDOLENCIA(char * M, char * D)
{
    DOLENCIA * PD;
    MEDICINA * PM;

    PD = new DOLENCIA(D);

    PM = ORIGEN;

    while(PM)
    {
        if(strcmpi(PM->NOM, M) == 0)
        {
            PD->SIG = PM->PDOL;
            PM->PDOL = PD;
            return;
        }
        PM = PM->SIG;
    }
}

void VADEMECUM::MIRAR()
{
    MEDICINA * PM;
    COMPONENTE * PC;
    DOLENCIA * PD;

    PM = ORIGEN;

    while(PM)
    {
        cout << "\nNOM: " << PM->NOM;
        PC = PM->PCOM;
        while(PC)
        {
            cout << "\nCOMP: " << PC->NOM;

            PC = PC->SIG;
        }
        PD = PM->PDOL;
        while(PD)
        {
            cout << "\nDOL: " << PD->NOM;

            PD = PD->SIG;
        }
        cout << "\n";
        PM = PM->SIG;
    }
}

class LABORATORIO
{
    public:
        LABORATORIO(char *, int );
        char NOM[20] ;
        int COSTO ;
        LABORATORIO * SIG ;
};

LABORATORIO::LABORATORIO(char * S, int P)
{
    strcpy(NOM, S);
    SIG = NULL;
    COSTO = P;
}

class COMPONENTE_QUIMICO
{
    public :
        COMPONENTE_QUIMICO(char *);
        char NOM[20] ;
        LABORATORIO * PLAB ;
        COMPONENTE_QUIMICO * SIG ;
};

COMPONENTE_QUIMICO::COMPONENTE_QUIMICO(char * S)
{
    strcpy(NOM, S);
    SIG = NULL;
    PLAB = NULL;
}

class LISTA_DE_PRECIOS
{
    private :
        COMPONENTE_QUIMICO * COMPORIGEN ;
    public :
        LISTA_DE_PRECIOS();
        void CARGARCOMPOQUIMICO(char *);
        void CARGARLABORATORIO(char *, char *, int );
        friend int VADEMECUM::CHEAPER (char *, LISTA_DE_PRECIOS &);
        friend int COMPONENTE::BUSCAR(LISTA_DE_PRECIOS &);
        void MIRAR();
};

LISTA_DE_PRECIOS::LISTA_DE_PRECIOS()
{
    COMPORIGEN = NULL;
}

void LISTA_DE_PRECIOS::CARGARCOMPOQUIMICO(char * S)
{
    COMPONENTE_QUIMICO * PCQ;

    PCQ = new COMPONENTE_QUIMICO(S);

    PCQ->SIG = COMPORIGEN;
    COMPORIGEN = PCQ;
}

void LISTA_DE_PRECIOS::CARGARLABORATORIO(char * M, char * L, int PRECIO)
{
    COMPONENTE_QUIMICO * PCQ;
    LABORATORIO * PL;

    PL = new LABORATORIO(L, PRECIO);

    PCQ = COMPORIGEN;

    while(PCQ)
    {
        if(strcmp(PCQ->NOM, M) == 0)
        {
            PL->SIG = PCQ->PLAB;
            PCQ->PLAB = PL;
            return;
        }
        PCQ = PCQ->SIG;
    }
}

void LISTA_DE_PRECIOS::MIRAR()
{
    COMPONENTE_QUIMICO * PCQ;
    LABORATORIO * PL;

    PCQ = COMPORIGEN;

    while(PCQ)
    {
        cout << "\nCOMP. QUIMICO: " << PCQ->NOM;
        PL = PCQ->PLAB;
        while(PL)
        {
            cout << "\nLAB: " << PL->NOM;
            cout << "\nPRECIO:  " << PL->COSTO;

            PL = PL->SIG;
        }
        cout << "\n";
        PCQ = PCQ->SIG;
    }
}

int VADEMECUM::CHEAPER(char * D, LISTA_DE_PRECIOS &LP)
{
    MEDICINA * PM;
    COMPONENTE * PC;
    DOLENCIA * PD;

    int AUX = 0, MIN = 0, INICIALIZADOR = 1;

    PM = ORIGEN;

    while(PM)
    {
        PD = PM->PDOL;
        while(PD)
        {
            if(strcmpi(D, PD->NOM))
            {
                AUX = 0;
                PC = PM->PCOM;
                while(PC)
                {
                    AUX += PC->BUSCAR(LP);
                    PC = PC->SIG;
                }
                if(INICIALIZADOR == 1)
                {
                    MIN = AUX;
                    INICIALIZADOR = 0;
                }
                if(AUX < MIN)
                {
                    MIN = AUX;
                }
            }
            PD = PD->SIG;
        }
        PM = PM->SIG;
    }
    return MIN;
}

int COMPONENTE::BUSCAR(LISTA_DE_PRECIOS &LP)
{
    COMPONENTE_QUIMICO * PQC;
    LABORATORIO * PL;
    int VALOR;

    PQC = LP.COMPORIGEN;

    while(PQC)
    {
        if(PQC->NOM, NOM)
        {
            PL = PQC->PLAB;
            if(PL)
            {
                VALOR = PL->COSTO;
            }
            else
            {
                return 0;
            }
            while(PL)
            {
                if(VALOR > PL->COSTO)
                {
                    VALOR = PL->COSTO;
                }
                PL = PL->SIG;
            }
        }
        PQC = PQC->SIG;
    }
    return VALOR;
}
int main()
{
    LISTA_DE_PRECIOS LP;
    VADEMECUM V;

    int VALOR = 0;

    cout << "\nMEDICAMENTOS";

    V.CARGARMEDICAMENTO("JARABE");
    V.CARGARMEDICAMENTO("PASTILLAS");
    V.CARGARMEDICAMENTO("CREMA");

    V.CARGARCOMPONENTE("JARABE", "AMOXICILINA");
    V.CARGARCOMPONENTE("JARABE", "OMEPREZOL");
    V.CARGARCOMPONENTE("PASTILLAS", "OMEPREZOL");
    V.CARGARCOMPONENTE("PASTILLAS", "LOSARTAN");
    V.CARGARCOMPONENTE("CREMA", "LOSARTAN");
    V.CARGARCOMPONENTE("CREMA", "CANNABIS");

    V.CARGARDOLENCIA("JARABE", "TOS");
    V.CARGARDOLENCIA("JARABE", "FIEBRE");
    V.CARGARDOLENCIA("PASTILLAS", "DOLOR DE CABEZA");
    V.CARGARDOLENCIA("PASTILLAS", "TOS");
    V.CARGARDOLENCIA("CREMA", "IRRITACION");
    V.CARGARDOLENCIA("CREMA", "LASTIMADURAS");

    V.MIRAR();

    cout << "\nLISTA DE PRECIOS";

    LP.CARGARCOMPOQUIMICO("AMOXICILINA");
    LP.CARGARCOMPOQUIMICO("INSULINA");
    LP.CARGARCOMPOQUIMICO("OMEPREZOL");
    LP.CARGARCOMPOQUIMICO("LEVOTIROXINA");
    LP.CARGARCOMPOQUIMICO("LOSARTAN");

    LP.CARGARLABORATORIO("AMOXICILINA", "SPUTNIK", 250);
    LP.CARGARLABORATORIO("AMOXICILINA", "PFIZER", 300);
    LP.CARGARLABORATORIO("INSULINA", "OXFORD", 920);
    LP.CARGARLABORATORIO("INSULINA", "JHONSON", 900);
    LP.CARGARLABORATORIO("OMEPREZOL", "SPUTNIK", 500);
    LP.CARGARLABORATORIO("OMEPREZOL", "ASTRAZENECA", 450);
    LP.CARGARLABORATORIO("LEVOTIROXINA", "JHONSON", 650);
    LP.CARGARLABORATORIO("LEVOTIROXINA", "SPUTNIK", 750);
    LP.CARGARLABORATORIO("LOSARTAN", "OXFORD", 700);
    LP.CARGARLABORATORIO("LOSARTAN", "PFIZER", 760);

    LP.MIRAR();

    VALOR = V.CHEAPER("IRRITACION", LP);

    cout << "\nEL VALOR DEL MEDICAMENTO MAS BARATO PARA LA TOS ES " << VALOR;

    return 0;
}
