using System;
using System.Collections.Generic;
using System.Linq;

namespace TesteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MinimunSwaps();
        }

        #region Amazon
        public static void ComposicaoCom2E4(int limit){
            IList<int> list = new List<int>(){2, 4};

            var result = add2and4(1, limit, list);

            foreach(var i in result){
                Console.WriteLine(i);
            }

            /*
            2, 4, 22, 24, 42, 44, 222, 224, 242, 244, 422, 424, 442, 444
            */
        }

        public static IList<int> add2and4(int iterator, int limit, IList<int> list){
            if((list.Max() * 10) >= limit)
                return list;

            IList<int> r = new List<int>(list);
            foreach (var i in list){
                if(i>iterator){
                    r.Add(int.Parse("2"+i));
                    r.Add(int.Parse("4"+i));
                }
            }
            
            return add2and4(iterator * 10, limit, r);
        }

        #endregion Amazon

        public static void MinimunSwaps(){
            IList<int> list = new List<int>(){7, 1, 3, 2, 4, 5, 6};
            int numSwaps = 0;
            for(var i = 0; i < list.Count; i++){
                while(i + 1 != list[i]){
                    int swapIndex = list[i] - 1;
                    int valAtIndex = list[i];
                    int valAtSwapIndex = list[swapIndex];
                    list[i] = valAtSwapIndex;
                    list[swapIndex] = valAtIndex;
                    numSwaps++;
                }
            }

            Console.WriteLine(numSwaps);
        }

        public static void MinimunSwaps2(){
            int[] arr = new int[]{4,3,1,2};

            int steps = 0;
            if(arr[arr.Length - 1] != arr.Length){
                double half =arr.Length / 2;
                int idxMax = (int)Math.Ceiling(half);
                var aux = arr[idxMax];
                arr[idxMax] = arr[0];
                arr[0] = aux;
                steps += 1;
            }

            for(var i = 0; i < arr.Length; i++){
                if (arr[i] != i + 1){
                    var idx = Array.IndexOf(arr, i + 1);

                    var temp = arr[idx];
                    arr[idx] = arr[i];
                    arr[i] = temp;
                    steps++;
                    Console.WriteLine(arr[i]);
                }
            }

            Console.WriteLine(steps);
        }

        public static void ArrayManipulation(){
            int n = 10;
            List<List<int>> queries = new List<List<int>>{new List<int>{2,2,8}, new List<int>{3,3,7}, new List<int>{1,1,1}, new List<int>{5,5,15}, new List<int>{9,9,100}};

            long[] arr = new long[n + 2];

            foreach(var i in queries){
                arr[i.ElementAt(0)] += i.ElementAt(2);
                arr[i.ElementAt(1) + 1] -= i.ElementAt(2);
                Console.WriteLine("a: " + i.ElementAt(0) + " = " + arr[i.ElementAt(0)] + " b: " + (i.ElementAt(1) + 1) + " = " + arr[i.ElementAt(1) + 1]);
            }

            long temp = 0;
            long maxNum = 0;
            for(var x = 0; x < arr.Length; x++){
                temp += arr[x];
                maxNum = maxNum < temp ? temp : maxNum;
            }

            Console.WriteLine("Resposta: " + maxNum);

        }

        public static void ArrayManipulationBruteForce(){
            int n = 10;
            List<List<int>> queries = new List<List<int>>{new List<int>{1,2,100}, new List<int>{2,5,100}, new List<int>{3,4,1000}};

            int[][] lista = queries.Select(i => i.ToArray()).ToArray();
            long[] arr = new long[n + 1];
            long ret = 0;

            for(var i = 0; i < lista.Length; i++){
                for(var x = lista[i][0]; x <= lista[i][1]; x++){
                    arr[x] += lista[i][2];
                    if (arr[x] > ret)
                        ret = arr[x];
                }
            }

            Console.WriteLine(arr.Max());
        }


        public static void NewYearChaos(){
            List<int> q = new List<int>(){2, 5, 1, 3, 4};

            //var result = new Dictionary<int, int>();
            //int qtde = 0;
            int swaps = 0;
            var arr = q.ToArray();

            for( int i = arr.Length - 1; i >= 0; i--){
                if (arr[i] != i + 1){ //Verifica se o índice + 1 é diferente do valor do array, se está certo eles são iguais
                    if((i-1) >= 0 && arr[i-1] == i + 1){
                        int temp = arr[i-1];
                        arr[i-1] = arr[i];
                        arr[i] = temp;
                        swaps++;
                    }
                    else if((i - 2) >= 0 && arr[i - 2] == i + 1){
                        var temp = arr[i - 2];
                        arr[i - 2] = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                        swaps += 2;
                    }
                    else{
                        Console.WriteLine("Too chaotic");
                        return;
                    }
                }
            }

            Console.WriteLine(swaps);

            // for(var i = 1; i < arr.Length; i++){
            //     Console.WriteLine(i);

            //     if (!arr.Contains(arr[i]))
            //         qtde = 0;
            //     else
            //         qtde = arr[i];

            //     if (arr[i -1] > arr[i]){
            //         var aux = arr[i -1];
            //         arr[i -1] = arr[i];
            //         arr[i] = aux;
            //         result[arr[i]] = ++qtde;
            //     }

            //     if(result[arr[i]] > 2){
            //         Console.WriteLine("Too chaotic");
            //         break;
            //     }
            // }
            
            //Console.WriteLine(result);

        }

        public static void PrimeiraSemRepeticao(){
            List<int> list = new List<int>(){0, 0, 1, 0, 1, 0, 0, 0, 1, 0};

            string test = "aaabcccd";

            for (var i = 0; i < test.Length; i++){
                if (test.IndexOf(test[i]) == test.LastIndexOf(test[i])){
                    Console.WriteLine(test[i]);
                    break;
                }
                    
            }

        }


    }
}
