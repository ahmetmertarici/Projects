import React from 'react'
import { Container } from 'react-bootstrap'
const HomePage = () => {
    return (
        <Container>
            <div className='d-flex flex-column align-items-center justify-content-center' style={{height:"85vh"}}>
                <h1 className='display-1 text-success'>Welcome</h1>
                <h2 className='display-5 text-danger'>Github Finder</h2>
            </div>
        </Container>
    )
}

export default HomePage