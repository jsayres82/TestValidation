namespace MicrowaveNetworks.Matrices.SymmetryExtension
{
    internal class SymmetryMatrix
    {

        public SymmetryMatrix(int numPorts) => NumberOfPorts = numPorts;

        public int NumberOfPorts { get; set; }

        public SymmetryMatrixElement OneOne { get; set; }
        public SymmetryMatrixElement OneTwo { get; set; }
        public SymmetryMatrixElement TwoOne { get; set; }
        public SymmetryMatrixElement TwoTwo { get; set; }
    }
}
