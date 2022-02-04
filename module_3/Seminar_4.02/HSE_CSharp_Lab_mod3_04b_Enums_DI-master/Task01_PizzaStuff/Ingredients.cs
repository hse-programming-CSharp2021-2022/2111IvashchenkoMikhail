using System;

namespace PizzaStuff
{
    [Flags]
    public enum Ingredients
    {
        Dough = 1, // 1
        Mozzarella = 2, //10
        Parmesan = 4, //100
        TomatoSauce = 8, // 1000
        Peperoni = 16, // 10000
        Olives = 32, // 100000
        Mushrooms = 64, // 1000000
        Tomatoes = 128, // 10000000
        Herbs = 256, // 100000000
        Pineapple = 512, // 1000000000
        Anchovies = 1024, // 10000000000
        Ham = 2048, // 100000000000
        OliveOil = 4096, // 1000000000000
    }
}
