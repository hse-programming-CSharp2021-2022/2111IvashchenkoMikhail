using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaStuff
{
    public class Pizzeria
    {
        // Склад для ингредиентов. Хранит количество каждого ингредиента.
        private Dictionary<Ingredients, int> storage = new();

        /// <summary>
        /// Привозит новые ингредиенты на склад.
        /// Увеличивает количество ингредиента ingredients на значение amount.
        /// </summary>
        /// <param name="ingredients"> Ингредиент, который будет привезен на склад. </param>
        /// <param name="amount"> Количество ингредиента. </param>
        public void DeliverIngredient(Ingredients ingredients, int amount)
        {
            foreach (var item in storage.Keys.Where(item => ingredients == item))
            {
                storage[item] += amount;
                return;
            }

            storage.Add(ingredients, amount);
        }

        /// <summary>
        /// Возвращет информацию о количестве каждого ингредиента на складе.
        /// </summary>
        public (string name, int amount)[] GetStorage()
        {
            var storageInfo = new (string name, int amount)[storage.Count];
            for (int i = 0; i < storage.Count; i++)
            {
                storageInfo[i] = (storage.ToArray()[i].Key.ToString(), storage.ToArray()[i].Value);
            }

            return storageInfo;
        }

        /// <summary>
        /// Готовит пиццу по рецепту.
        /// </summary>
        /// <param name="recipe"> Рецепт пиццы. </param>
        /// <returns> Приготовленная пицца. </returns>
        /// <exception cref="PizzaException"> Если на складе не хватает ингредиентов, чтобы приготовить пиццу по рецепту. </exception>
        public Pizza MakePizza(PizzaRecipe recipe)
        {
            if (!HasIngredients(recipe))
            {
                throw new PizzaException("There're no required ingredients!");
            }
            
            UseIngredients(recipe);
            
            return new Pizza(recipe);
        }

        /// <summary>
        /// Проверяет, есть ли на складе ингредиенты для рецепта.
        /// </summary>
        /// <param name="recipe"> Рецепт, наличие ингредиентов необходимо проверить. </param>
        /// <returns> true, если все ингредиенты есть на складе, false иначе. </returns>
        private bool HasIngredients(PizzaRecipe recipe)
        {
            var requiredIngredients = recipe.Ingredients;

            if (storage.Count == 0)
            {
                return false;
            }
            
            foreach (Ingredients ingredient in Enum.GetValues(typeof(Ingredients)))
            {
                if ((ingredient & requiredIngredients) == 0) continue;
                if (!storage.ContainsKey(ingredient) || storage[ingredient] == 0)
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Удаляет со склада по одному ингредиенту из рецепта.
        /// </summary>
        /// <param name="recipe"></param>
        private void UseIngredients(PizzaRecipe recipe)
        {
            var requiredIngredients = recipe.Ingredients;
            var storageIngredients = storage.Keys;
            foreach (Ingredients ingredient in storageIngredients)
            {
                if ((ingredient & requiredIngredients) != 0)
                {
                    storage[ingredient] -= 1;
                }
            }
        }
    }
}
