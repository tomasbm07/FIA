using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Randomizations;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Infrastructure.Framework.Texts;
using GeneticSharp.Runner.UnityApp.Car;

public class Tournament : SelectionBase
{
    protected int Size { get; set; }
    public Tournament() : this(2)
    {
    }


    
    public Tournament(int size) : base(2)
    {
        Size = size;
    }

    



    protected override IList<IChromosome> PerformSelectChromosomes(int number, Generation generation)
    {

        IList<CarChromosome> population = generation.Chromosomes.Cast<CarChromosome>().ToList(); // Current Population: We will select individuals from here 
        IList<IChromosome> parents = new List<IChromosome>(); // List that will return the individuals that will mate, i.e. that will undergo variation

        //YOUR CODE HERE
        for (int i = 0; i < number; i++) {
            int[] randomIndexes = RandomizationProvider.Current.GetUniqueInts(Size, 0, population.Count);
            IChromosome winner = null;
            float winnerFitness = -1;

            for (int k = 0; k < Size; k++) {
                // Maximização
                if (winner == null || population[k].Fitness > winnerFitness) {
                    winner = population[k];
                    winnerFitness = population[k].Fitness;
                }
            }

            parents.Add(winner);
        }   

        return parents;
    }

}
