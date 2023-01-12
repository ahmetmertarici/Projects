import React from 'react'
import Container from 'react-bootstrap/Container'
import Navbar from 'react-bootstrap/Navbar'
import Nav from 'react-bootstrap/Nav'
import { VscGithub } from "react-icons/vsc";
import { NavLink } from 'react-router-dom';

const NavBar = () => {
    return (
        <Navbar bg="primary" variant="dark">
            <Container>
                <Navbar.Brand>
                    <NavLink className='nav-link' to='/'><VscGithub /> Github Finder</NavLink>
                </Navbar.Brand>
                <Nav className="me-auto">
                    <NavLink className='nav-link' to="/search">Search</NavLink>

                </Nav>
            </Container>
        </Navbar>

    )
}

export default NavBar