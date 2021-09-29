


namespace locadora_filmes.APPLICATION.Commons {
    public class Response {
        public int status { get; private set; }
        public object obj { get; private set; }


        public Response(int status, object obj) {
            this.status = status;
            this.obj = obj;
        }

    }
}
