#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define num 3
#define cant 3

struct fecha
{
    int dia;
    int mes;
    int anio;
};

struct pelicula
{
    char nombre[30];
    char personajes[cant][30];
    struct fecha fecha_lanz;
};

void ingreso(struct pelicula [], int );
void ordenamiento(struct pelicula [], int );
void mirar(struct pelicula [], int );

int main()
{
    struct pelicula vec[num];

    ingreso(vec, num);
    ordenamiento(vec, num);
    mirar(vec, num);

    return 0;
}
void ingreso(struct pelicula v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("Ingrese el nombre de la pelicula: ");
        fflush(stdin);
        gets(v[i].nombre);

        for(int j = 0; j < cant; j ++)
        {
            printf("Ingrese nombre del personaje nro %d: ", j + 1);
            fflush(stdin);
            gets(v[i].personajes[j]);
        }

        printf("Ingrese la fecha de lanzamiento(dd/mm/aaaa): ");
        fflush(stdin);
        scanf("%d/%d/%d", &v[i].fecha_lanz.dia, &v[i].fecha_lanz.mes, &v[i].fecha_lanz.anio);

        printf("\n");
    }
}
void ordenamiento(struct pelicula v[], int n)
{
    struct pelicula aux;

    for(int i = 0; i < n - 1; i ++)
    {
        for(int j = i + 1; j < n - 1; j ++)
        {
            if((v[j].fecha_lanz.anio < v[i].fecha_lanz.anio) ||
                    (v[j].fecha_lanz.anio == v[i].fecha_lanz.anio && v[j].fecha_lanz.mes < v[i].fecha_lanz.mes) ||
                    (v[j].fecha_lanz.anio == v[i].fecha_lanz.anio && v[j].fecha_lanz.mes == v[i].fecha_lanz.mes && v[j].fecha_lanz.dia < v[i].fecha_lanz.dia) ||
                    (v[j].fecha_lanz.anio == v[i].fecha_lanz.anio && v[j].fecha_lanz.mes == v[i].fecha_lanz.mes && v[j].fecha_lanz.dia == v[i].fecha_lanz.dia && strcmp(v[j].nombre, v[i].nombre)))
            {
                aux = v[i];
                v[i] = v[j];
                v[j] = aux;
            }
        }
    }
}
void mirar(struct pelicula v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("\n%s", v[i].nombre);

        for(int j = 0; j < n; j ++)
        {
            printf("\n%s ", v[i].personajes[j]);
        }
        printf("\n%d  %d  %d", v[i].fecha_lanz.dia, v[i].fecha_lanz.mes, v[i].fecha_lanz.anio);
        printf("\n");
    }
}
