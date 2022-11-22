#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define num 4

struct kit
{
 int codigo;
 char municipio[30];
 int alarmas_activas[8];
};

void relleno(struct kit [], int );
void mostrar(struct kit [], int );
int kitsActivados(struct kit [], int );

int main()
{
    struct kit vec[num];
    int total = 0;

    relleno(vec, num);
    mostrar(vec, num);
    total = kitsActivados(vec, num);

    printf("\nLa cantidad de alarmas activas son: %d", total);

    return 0;
}
void relleno(struct kit v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("\nIngrese el nombre de su municipio: ");
        fflush(stdin);
        gets(v[i].municipio);

        printf("Ingrese el codigo del kit: ");
        fflush(stdin);
        scanf("%d", &v[i].codigo);

        for(int j = 0; j < 8; j ++)
        {
            v[i].alarmas_activas[j] = 1;
        }
    }
    printf("\n");
}
void mostrar(struct kit v[], int n)
{
    char auxMunicipio[30][10] = {""};
    int registrado = 0;

    for(int i = 0; i < n; i ++)
    {
        registrado = 0;
        if(i == 0)
        {
            printf("%s\n", v[i].municipio);
            strcpy(auxMunicipio[i], v[i].municipio);
        }
        else
        {
            for(int j = 0; j < n; j ++)
            {
                if(strcmpi(v[i].municipio, auxMunicipio[j]) == 0)
                {
                    registrado = 1;
                    break;
                }
            }
            if(registrado == 0)
            {
                printf("%s\n", v[i].municipio);
                strcpy(auxMunicipio[i] ,v[i].municipio);
            }
        }
    }
}
int kitsActivados(struct kit v[], int n)
{
    int activas = 0;
    int alarmasON = 0;

    for(int i = 0; i < n; i ++)
    {
        activas = 0;
        for(int j = 0; j < 8; j ++)
        {
            if(v[i].alarmas_activas[j] == 1)
            {
                activas ++;
            }
        }
        if(activas == 8)
        {
            alarmasON ++;
        }
    }
    return alarmasON;
}
