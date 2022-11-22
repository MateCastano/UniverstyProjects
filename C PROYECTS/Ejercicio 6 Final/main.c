#include <stdio.h>
#include <stdlib.h>

#define num 4
#define filas 4
#define columnas 6

struct SALA
{
    int codigo;
    int butaca[filas][columnas];
    char peli[30];
};

void relleno(struct SALA [], int );
int mas_vista(struct SALA [], int );
int buscar_peli(struct SALA [], char [] );

int main()
{
    struct SALA vec[num];
    char titulo[30];

    relleno(vec, num);

    printf("\nEl codigo de la pelicula mas vista es: %d", (mas_vista(vec, num)));

    printf("\nIngrese el titulo que desea buscar: ");
    fflush(stdin);
    gets(titulo);

    printf("El codigo del titulo que esta buscando es: %d", (buscar_peli(vec, titulo)));

    return 0;
}
void relleno(struct SALA v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("Ingrese el titulo de la pelicula: ");
        fflush(stdin);
        gets(v[i].peli);

        v[i].codigo = i + 1;

        for(int j = 0; j < filas; j ++)
        {
            for(int k = 0; k < columnas; k ++)
            {
                v[i].butaca[j][k] = 0 + rand() % 2;
            }
        }
    }
}
int mas_vista(struct SALA v[], int n)
{
    int codigo = 0;
    int cont = 0;
    int auxCont = 0;

    for(int i = 0; i < n; i ++)
    {
        auxCont = 0;
        for(int j = 0; j < filas; j ++)
        {
            for(int k = 0; k < columnas; k ++)
            {
                if(v[i].butaca[j][k] == 1)
                {
                    auxCont ++;
                }
            }
        }
        if(auxCont > cont)
        {
            codigo = v[i].codigo;
            cont = auxCont;
        }
    }

    return codigo;
}
int buscar_peli(struct SALA v[], char titulo[])
{
    int codigo = 0;
    for(int i = 0; i < num; i ++)
    {
        if(strcmpi(v[i].peli, titulo) == 0)
        {
            codigo = v[i].codigo;
        }
        else
        {
            codigo = -1;
        }
    }
    return codigo;
}
