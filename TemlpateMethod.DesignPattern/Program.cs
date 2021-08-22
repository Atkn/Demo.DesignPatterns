using System;

namespace TemlpateMethod.DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgortihm algortihm;
            Console.WriteLine("Mans");
            algortihm = new MensScoringAlgorithm();
            Console.WriteLine(algortihm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.WriteLine("Woman");
            algortihm = new WomansScoringAlgorithm();
            Console.WriteLine(algortihm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.WriteLine("Children");
            algortihm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algortihm.GenerateScore(8, new TimeSpan(0, 2, 34)));
            Console.ReadLine();

        }
    }

    abstract class ScoringAlgortihm
    {
        public int GenerateScore(int hits, TimeSpan time) 
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverrallScore(score, reduction);
        }

        public abstract int CalculateBaseScore(int hits);

        public abstract int CalculateOverrallScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);
    }


    class MensScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverrallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomansScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverrallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
    }
    class ChildrensScoringAlgorithm : ScoringAlgortihm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        public override int CalculateOverrallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
    }

}
