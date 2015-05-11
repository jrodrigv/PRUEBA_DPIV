using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace PRUEBA_DPIV.Tests
{
    public class NodeTests
    {
    
        [Fact]
        public void ATreeWithOnlyRootHasOneUniquePath()
        {
            var sut = new Node(){value = 1};


            var result = UniquePaths(sut);

            Assert.Equal(1,result);
        }

        [Fact]

        public void ATreeWithTwoUniqueLeafsHasTwoUniquePaths()
        {
            var sut = new Node()
            {
                value = 1,
                left = new Node() {value = 2},
                right = new Node() { value = 3},
            
            };

            var result = UniquePaths(sut);
             Assert.Equal(2,result);
        }

        [Fact]
        public void ATwoLevelsWithDuplicatesValuesOnLeafsHasNoUniquePaths()
        {
            /*
             *    1
             *  2   3
             * 1 2 1 3
             */
            var sut = new Node()
            {
                value = 1,
                left = new Node()
                {
                    value = 2,
                    left = new Node() { value = 1},
                    right = new Node() { value = 2}
                },
                right = new Node()
                {
                    value = 3,
                     left = new Node() { value = 1},
                     right = new Node() { value = 3}
                },
            
            };

            var result = UniquePaths(sut);
             Assert.Equal(0,result);
        }

        [Fact]
        public void ATwoLevelsTreeWithoutDuplicatesValuesOnLeafsHasFourUniquePaths()
        {
            /*
             *    1
             *  2   3
             * 4 5 6 7
             */
            var sut = new Node()
            {
                value = 1,
                left = new Node()
                {
                    value = 2,
                    left = new Node() { value = 4 },
                    right = new Node() { value = 5 }
                },
                right = new Node()
                {
                    value = 3,
                    left = new Node() { value = 6 },
                    right = new Node() { value = 7 }
                },

            };

            var result = UniquePaths(sut);
            Assert.Equal(4, result);
        }
        private int UniquePaths(Node sut)
        {
          
            if (sut.left == null && sut.right == null)
            {
                return 1;
            }
            
            var uniquePathsLeft = UniquePathsProcess(sut.left, new List<int> { sut.value });

            var uniquePathsRight = UniquePathsProcess(sut.right, new List<int> { sut.value });

            return  uniquePathsLeft + uniquePathsRight;
        }

        private int UniquePathsProcess(Node sut, List<int> path)
        {
            if (sut == null || path.Contains(sut.value)) return 0;

            if (sut.left == null && sut.right == null && !path.Contains(sut.value)) return 1;

            var newPath = path.ToList();
            newPath.Add(sut.value);

            return UniquePathsProcess(sut.left, newPath) + UniquePathsProcess(sut.right, newPath);

        }
     }
}

