import { useCallback } from "react";
import { Nav, Navbar, NavDropdown } from "react-bootstrap";
import { useAppDispatch } from "../app/hooks";
import { logout } from "../store/userSession/api";
import { useLocation } from "react-router-dom";
import { NavItem } from "./NavItem";

const Header: React.FC = () => {
    const location = useLocation();
    const dispatch = useAppDispatch();
    const dispatchLogout = useCallback(() => {
        dispatch(logout());
    }, [dispatch]);

    return (
        <Navbar className="px-3" expand="lg">
            <Navbar.Brand>Learning Platform</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav
                    className="me-auto"
                    activeKey={location.pathname.replace("/", "")}
                >
                    <NavItem to="/home" text="Home" />
                    <NavItem to="/users" text="Words" />
                    <NavItem to="/items" text="Add Words" />
                    <NavItem to="/releases" text="Quiz" />
                    <NavItem to="/categories" text="English Tenses" />
                </Nav>
                <Nav>
                    <NavDropdown
                        title={
                            <div className="pull-left">
                                <img
                                    className="me-2"
                                    style={{
                                        width: "40px",
                                        borderRadius: "50%",
                                    }}
                                    src={
                                        "https://avatars.githubusercontent.com/u/42341432?s=400&u=72b92a3d6667326c365e8ee355acd311e80019f6&v=4"
                                    }
                                    alt="user pic"
                                />
                                Fabian
                            </div>
                        }
                        id="basic-nav-dropdown"
                        align="end"
                    >
                        <NavDropdown.Item href="#action/3.1">
                            Profile
                        </NavDropdown.Item>
                        <NavDropdown.Item
                            onClick={(event) => {
                                event.preventDefault();
                                dispatchLogout();
                            }}
                        >
                            Logout
                        </NavDropdown.Item>
                    </NavDropdown>
                </Nav>
            </Navbar.Collapse>
        </Navbar>
    );
};
export default Header;
