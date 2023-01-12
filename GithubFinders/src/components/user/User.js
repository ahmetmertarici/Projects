import React from 'react'
import Card from 'react-bootstrap/Card'
import Col from 'react-bootstrap/Col'
import { NavLink } from 'react-router-dom'
import './User.css'


const User = ({ user }) => {
    return (
        <Col lg={2} md={3} sm={4} xs={6} className="mb-2">
            <Card>
                <Card.Img src={user.avatar_url} />
                <Card.Body>

                    <Card.Title>
                        <h5 className='display-6 fs-6 fw-bold'>{user.login}</h5>
                    </Card.Title>

                    <a className='btn btn-sm btn-primary me-2' href={user.html_url}>Profile</a>
                    <NavLink className='btn btn-sm btn-warning' to={`/getuser/${user.login}`}>Details</NavLink>

                </Card.Body>
            </Card>
        </Col >
    )
}

export default User