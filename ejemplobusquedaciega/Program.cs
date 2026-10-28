string[,] Arreglo =
{         
    { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" },
    { "|", "A", "*", "*", "*", "*", "*", "*", "*", "|" },
    { "|", "|", "*", "|", "|", "|", "|", "*", "|", "|" },
    { "|", "*", "*", "|", "|", "*", "|", "*", "|", "|" },
    { "|", "*", "|", "|", "|", "*", "|", "*", "*", "|" },
    { "|", "*", "*", "B", "|", "*", "|", "|", "|", "|" },
    { "|", "|", "|", "|", "|", "*", "*", "*", "*", "|" },
    { "|", "|", "|", "|", "*", "|", "*", "|", "*", "|" },
    { "|", "|", "*", "*", "|", "*", "|", "|", "*", "|" },
    { "|", "|", "|", "|", "|", "*", "|", "|", "*", "|" },
    { "|", "*", "*", "*", "|", "*", "|", "|", "*", "|" },
    { "-", "-", "-", "-", "-", "-", "-", "-", "-", "-" }
};

int posX = 1;
int posY = 1;

int tempX = 0;
int tempY = 0;

int[,] Respaldo = new int[3, 2];

bool isBlockend = false;
bool isFihish = false;

Imprimir();
Console.ReadLine();

do
{
    mover();
} while (!isFihish);

void mover()
{
    if (Arreglo[posY, posX + 1] == "B" || Arreglo[posY + 1, posX] == "B" ||
        Arreglo[posY, posX - 1] == "B" || Arreglo[posY - 1, posX] == "B")
    {
        Console.WriteLine("¡Se encontró la meta B!");
        isFihish = true;
    }
    else if (Arreglo[posY, posX + 1] == "*")
    {
        if (Arreglo[posY + 1, posX] == "*")
        {
            Respaldo[tempY, tempX] = posY;
            Respaldo[tempY, tempX + 1] = posX;
            
            Console.WriteLine("Respaldo guardado en: " + Respaldo[tempY, tempX] + " " + Respaldo[tempY, tempX + 1]); 
            tempY++;
        }
        
        Arreglo[posY, posX + 1] = "A";
        posX++;
        Console.WriteLine("Arreglo[" + posY + "],[" + posX + "]");
        isBlockend = false;
    }
    else if (Arreglo[posY + 1, posX] == "*")
    {
        Arreglo[posY + 1, posX] = "A";
        posY++;
        Console.WriteLine("Arreglo[" + posY + "],[" + posX + "]");
        isBlockend = false;
    }
    else if (Arreglo[posY, posX - 1] == "*")
    {
        Arreglo[posY, posX - 1] = "A";
        posX--;
        Console.WriteLine("Arreglo[" + posY + "],[" + posX + "]");
        isBlockend = false;
    }
    else if (Arreglo[posY - 1, posX] == "*")
    {
        Arreglo[posY - 1, posX] = "A";
        posY--;
        Console.WriteLine("Arreglo[" + posY + "],[" + posX + "]");
        isBlockend = false;
    }
    else
    {
        isBlockend = true;
        if (tempY > 0)
        {
            tempY--;
            posY = Respaldo[tempY, 0];
            posX = Respaldo[tempY, 1];
            Console.WriteLine("El puntero regresó a " + posY + " " + posX);
        }
        else
        {
            Console.WriteLine("No hay más caminos disponibles.");
            isFihish = true;
        }
    }
    Imprimir();
    Console.ReadLine();
}
void Imprimir()
{
    for (int i = 0; i < 12; i++)
    {
        for (int j = 0; j < 10; j++)
        {
            Console.Write(Arreglo[i, j] + " ");
        }
        Console.Write("\n");
    }   
}

