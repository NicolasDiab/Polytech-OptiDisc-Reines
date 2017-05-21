using Metier.Finesse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public class GeneticAlgo : Algo
    {

        private List<GeneticBoard> firstGeneration;
        private List<GeneticBoard> currentGeneration;
        private int nbGeneration;
        private int currentGenerationNumber;

        public List<GeneticBoard> FirstGeneration { get => firstGeneration; set => firstGeneration = value; }

        public GeneticAlgo(List<GeneticBoard> firstGeneration, int nbGeneration) {
            this.nbGeneration = nbGeneration;
            this.firstGeneration = firstGeneration;
            this.FinesseStrategy = new NbQueenConflict();
        }

        public override string getAdvancement()
        {
            return Math.Round(((double)this.currentGenerationNumber / (double)this.nbGeneration),3) * 100 + " % ";
        }

        protected override void algo()
        {
            List<GeneticBoard> nextGeneration;
            currentGeneration = firstGeneration;
            this.XMin = this.firstGeneration[0];
            this.FMin = this.FinesseStrategy.compute((GeneticBoard)XMin);
            for (this.currentGenerationNumber = 0; this.currentGenerationNumber < this.nbGeneration; this.currentGenerationNumber++) {
                nextGeneration = new List<GeneticBoard>();
                int numberReproduction = currentGeneration.Count * 2 / 3;
                nextGeneration.AddRange(this.reproduction(this.currentGeneration, numberReproduction));
                nextGeneration.AddRange(this.crossOver(this.currentGeneration, currentGeneration.Count - numberReproduction));
                nextGeneration = this.mutation(this.currentGeneration, 0.05);
                this.currentGeneration = nextGeneration;
            }
        }

        private List<GeneticBoard> mutation(List<GeneticBoard> x, double probability)
        {
            List<GeneticBoard> solutions = x;
            Random rand = new Random();

            foreach (GeneticBoard solution in solutions)
            {
                if (rand.Next(0, 1) <= probability)
                {
                    solution.muter();
                }
            }

            return solutions;
        }

        private List<GeneticBoard> reproduction(List<GeneticBoard> x, int numberToSelect)
        {
            // dictionnary that contains <Borad, minProbability>
            Dictionary<GeneticBoard, double> dictionnaryProba = new Dictionary<GeneticBoard, double>();
            Dictionary<GeneticBoard, int> dictionnaryFitness = new Dictionary<GeneticBoard, int>();

            //compute fitness for each board and in total
            int fitnessTotal = 0;
            foreach (GeneticBoard solution in x)
            {
                int fitness = this.FinesseStrategy.compute((GeneticBoard)solution);
                fitnessTotal += fitness;
                dictionnaryFitness.Add(solution, fitness);
                if (fitness < FMin) {
                    this.XMin = new GeneticBoard(solution.Positions, solution.N);
                    this.XMin = solution;
                    this.FMin = fitness;
                }
            }

            // link a min probability to each board - like a wheel
            double totalProba = 0;
            foreach (GeneticBoard solution in x)
            {
                int fitness = 0;
                dictionnaryFitness.TryGetValue(solution, out fitness);

                dictionnaryProba.Add(solution, 1 - (fitness / fitnessTotal) + totalProba); // 1- proba to minimixe fitness and not maximize !
                totalProba += fitness / fitnessTotal;
            }

            // turn the wheel !!!
            List<GeneticBoard> solutions = new List<GeneticBoard>();
            Random rand = new Random();
            double proba;

            for (int i = 0; i < numberToSelect; i++)
            {
                proba = rand.NextDouble();

                //get solution for given proba
                GeneticBoard soluceBoard = null;
                double soluceProba = double.MaxValue; // initialise with +infinite
                foreach (var pair in dictionnaryProba)
                {
                    //keep only the smallest solution which is bigger that given proba
                    if (pair.Value >= proba && pair.Value <= soluceProba)
                    {
                        soluceBoard = pair.Key;
                        soluceProba = pair.Value;
                    }
                }

                solutions.Add(soluceBoard);
            }

            return solutions;
        }
        
        private List<GeneticBoard> crossOver(List<GeneticBoard> x, int numberCrossOver)
        {
            List<GeneticBoard> solutions = x;
            Random rand = new Random();

            for (int i = 0; i < numberCrossOver; i++)
            {
                // select 2 parents
                int indexParent1 = rand.Next(0, solutions.Count - 1);
                int indexParent2 = rand.Next(0, solutions.Count - 1);
                GeneticBoard parent1 = solutions[indexParent1];
                GeneticBoard parent2 = solutions[indexParent2];

                // create 2 children - slice parents at the middle
                GeneticBoard children1 = parent1;
                children1.Positions = parent1.Positions.Take(parent1.Positions.Length / 2).Concat(parent2.Positions.Skip(parent2.Positions.Length / 2)).ToArray();

                GeneticBoard children2 = parent2;
                children2.Positions = parent2.Positions.Take(parent2.Positions.Length / 2).Concat(parent1.Positions.Skip(parent1.Positions.Length / 2)).ToArray();

                // in the tab, replace the parents with the children
                solutions[indexParent1] = children1;
                solutions[indexParent2] = children2;
            }

            return solutions;
        }

    }
}
