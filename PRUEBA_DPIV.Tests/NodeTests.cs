using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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
          
        public void ADeepTreeWithDuplicateValuesOnLeafsHasNoUniquePaths()
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
            
        private int UniquePaths(Node sut)
        {
            throw new NotImplementedException();
        }  
        }
    }

