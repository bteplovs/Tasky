import { NavLink } from "react-router-dom";

const NavBar = () => {
    return (
        <nav className="flex flex-col md:flex-row justify-between items-center bg-blue-500 p-3">
            <div className="hover:bg-white rounded-xl p-2 active:translate-y-0.5 active:shadow-lg">
                <NavLink to="/boards" className="font-mono p-2 text-2xl text-white hover:text-blue-500">
                    Tasky
                </NavLink>
            </div>
        </nav>
    );
}

export default NavBar;