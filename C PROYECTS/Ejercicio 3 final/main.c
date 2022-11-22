#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define num 3
#define cant 3

struct boya
{
    char codigo[6];
    float mediciones[cant];
};

void relleno(struct boya [], int , int );
void promedioMayor(struct boya [], int , int );
int boyasVacias(struct boya [], int , int );

int main()
{
    struct boya vec[num];
    int total = 0;

    relleno(vec, num, cant);
    promedioMayor(vec, num, cant);
    total = boyasVacias(vec, num, cant);

    printf("\nLa cantidad de boyas con sus mediciones en cero son: %d", total);
    printf("\n");

    return 0;
}
void relleno(struct boya v[], int n, int c)
{
    for(int i = 0; i < n; i ++)
    {
        printf("Ingrese el codigo de la boya: ");
        fflush(stdin);
        gets(v[i].codigo);

        for(int j = 0; j < c; j ++)
        {
            printf("Ingresa la medicion de la boya Nro %d: ", j + 1);
            fflush(stdin);
            scanf("%f", &v[i].mediciones[j]);
        }
        printf("\n");
    }
}
void promedioMayor(struct boya v[], int n, int c)
{
    float auxResultado = 0;
    float resultadoFinal = 0;
    char boyaMayor[10];

    for(int i = 0; i < n ; i ++)
    {
        for(int j = 0; j < c; j ++)
        {
            auxResultado =+ v[i].mediciones[j];
        }
        if(auxResultado > resultadoFinal)
        {
            resultadoFinal = auxResultado;
            strcpy(boyaMayor, v[i].codigo);
        }
    }
    printf("\n");
    printf("\nEl codigo de la boya mas grande es: %s", boyaMayor);
}
int boyasVacias(struct boya v[], int n, int c)
{
    int boyas = 0;
    int cantFinal = 0;

    for(int i = 0; i < n; i ++)
    {
        boyas = 0;
        for(int j = 0; j < c; j ++)
        {
            if(v[i].mediciones[j] == 0)
            {
                boyas ++;
            }
        }
        if(boyas == c)
        {
            cantFinal ++;
        }
    }
    return cantFinal;
}
