using System;

public class Chef
{
    private Carrot GetCarrot()
    {
        return new Carrot();
    }

    private Potato GetPotato()
    {
        return new Potato();
    }

    private void Peel(Vegetable vegetable)
    {
    }

    private void Cut(Vegetable vegetable)
    {
    }

    private Bowl GetBowl()
    {
        return new Bowl();
    }

    public void Cook()
    {
        Potato potato = this.GetPotato();
        this.Peel(potato);
        this.Cut(potato);

        Carrot carrot = this.GetCarrot();
        this.Peel(carrot);
        this.Cut(carrot);

        Bowl bowl = this.GetBowl();
        bowl.Add(potato);
        bowl.Add(carrot);
    }
}
