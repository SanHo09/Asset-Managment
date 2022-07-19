function Login() {
    return ( 
        <div>
            <Routes>
              <Route path= {PAGE.LOGIN} element={<Login />} />
            </Routes>
        </div>
    );
}

export default Login;