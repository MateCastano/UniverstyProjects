#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define num 3
#define not 10

struct alumno
{
    char nombre[30];
    int notas[not];
};

void relleno(struct alumno [], int );
void mostrar(struct alumno [], int );
void materias(struct alumno [], int , char []);

int main()
{
    struct alumno vec[num];
    char materia[20];

    relleno(vec, num);
    mostrar(vec, num);

    printf("\nIngrese la materia: ");
    fflush(stdin);
    gets(materia);

    materias(vec, num, materia);

    return 0;
}
void relleno(struct alumno v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("Ingrese nombre del alumno: ");
        fflush(stdin);
        gets(v[i].nombre);

        for(int j = 0; j < not; j ++)
        {
            v[i].notas[j] = 1 + rand() % 10;
        }
    }
}
void mostrar(struct alumno v[], int n)
{
    char materias[10][10] = {"MAT", "FIS", "QUI", "ECO", "ALG", "INF", "LEG", "TEC", "RED", "PRO"};

    printf("\n");

    for(int i = 0; i < 10; i ++)
    {
        printf("\t  %s", materias[i]);
    }
    for(int i = 0; i < n; i ++)
    {
        printf("\n%s", v[i].nombre);
        for(int j = 0; j < not; j ++)
        {
            printf("\t  %d", v[i].notas[j]);
        }
        printf("\n");
    }
}
void materias(struct alumno v[], int n, char materia[])
{
    char materias[][15] = {"MATEMATICA", "FISICA", "QUIMICA", "ECONOMIA", "ALGEBRA", "INFORMATICA",
                            "LEGISLACION", "TECNOLOGIA", "REDACCION", "PROYECTO"};
    int numeroMateria;

    for(int i = 0; i < n; i ++)
    {
        if(strcmpi(materia,materias[i]) == 0)
        {
            numeroMateria = i;
        }
    }

    printf("\n\n\t Los alumnos que deben rendir examen son: ");

    for(int i = 0; i < n; i ++)
    {
        if(v[i].notas[numeroMateria] < 4)
        {
            printf("\n\n\t %-12s", v[i].nombre);
        }
    }
}
