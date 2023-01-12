import React, { useContext } from 'react'
import { Container, Row } from 'react-bootstrap'
import Loading from '../loading/Loading'
import User from '../user/User'
import { AppContext } from '../../contexts/AppContext'

const Users = () => {
    const ctx = useContext(AppContext);

    if (ctx.loading) {
        return <Loading />
    } else {
        return (
            <Container>
                <Row className='mt-3'>
                    {
                        ctx.users.map((u) => <User user={u} key={u.id} />)
                    }
                </Row>
            </Container>
        )
    }
}

export default Users