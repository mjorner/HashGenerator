namespace HashGenerator {
    class Program {
        public static void Main(string[] args) {
            new Program().Run();
        }

        public void Run() {
            new Argon2HashGenerator().Generate();
            new SCryptHashGenerator().Generate();
            new BCryptHashGenerator().Generate();
            new Sha256HashGenerator().Generate();
            new Sha512HashGenerator().Generate();
            new Md5HashGenerator().Generate();

            new HashRunTimeTester(new Argon2HashGenerator(), 10).Run();
            new HashRunTimeTester(new SCryptHashGenerator(), 10).Run();
            new HashRunTimeTester(new BCryptHashGenerator(), 10).Run();
            new HashRunTimeTester(new Sha256HashGenerator(), 100000).Run();
            new HashRunTimeTester(new Sha512HashGenerator(), 100000).Run();
            new HashRunTimeTester(new Md5HashGenerator(), 100000).Run();
        }
    }
}