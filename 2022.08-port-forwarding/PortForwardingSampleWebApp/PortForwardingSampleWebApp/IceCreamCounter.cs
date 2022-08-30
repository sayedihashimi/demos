namespace PortForwardingSampleWebApp {
    public class IceCreamCounter {
        private int _vanilla = 0;
        private int _chocolate = 0;
        private int _strawberry = 0;

        public int IncrementVanilla() {
            _vanilla++;
            return _vanilla;
        }
        public int IncrementChacolate() {
            _chocolate++;
            return _chocolate;
        }
        public int IncrementStrawberry() {
            _strawberry++;
            return _strawberry;
        }

        public int Vanilla {
            get { return _vanilla; }
        }
        public int Chocolate {
            get { return _chocolate; }
        }
        public int Strawberry {
            get { return _strawberry; }
        }
    }
}
