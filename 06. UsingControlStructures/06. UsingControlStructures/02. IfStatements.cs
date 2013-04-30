using System;
/*
 *  
 Refactor the following if statements: 


 Potato potato;
 //... 
 if (potato != null)
   if(!potato.HasNotBeenPeeled && !potato.IsRotten)
	Cook(potato);

 * 
 * 
 * 

 if (x >= MIN_X && (x =< MAX_X && ((MAX_Y >= y && MIN_Y <= y) && !shouldNotVisitCell)))
 {
   VisitCell();
 }

 
 */

class IfStatements
{
    const int MIN_X = -1000;
    const int MAX_X = 1000;
    const int MIN_Y = -1000;
    const int MAX_Y = 1000;

    public void CookPotatos()
    {
        Potato potato = new Potato();

        //... 

        if (potato == null)
        {
            throw new ArgumentNullException("There is no potato to cook!");
        }

        if (potato.isPeeled && !potato.isRotten)
        {
            Cook(potato);
        }
    }

    public void ShouldVisitCell(int x, int y, bool shouldVisitCell)
    {
        bool inRange = ((x >= MIN_X) && (x <= MAX_X) && (y >= MIN_Y) && (y <= MAX_Y));

        if (inRange && shouldVisitCell)
        {
            VisitCell(x, y);
        }
    }

    private void VisitCell(int x, int y)
    {
    }

    private void Cook(Vegetable vegetable)
    {
    }
}