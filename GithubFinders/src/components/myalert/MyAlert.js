import React, { useContext } from 'react'
import { Alert, Container } from 'react-bootstrap'
import { AppContext } from '../../contexts/AppContext';
const MyAlert = () => {
    const ctx = useContext(AppContext);
    {
        if (ctx.show) {
            return (
                <>
                    {ctx.alert !== null &&
                        (
                            <Container className='mt-3'>
                                <Alert onClose={() => { ctx.setShow(false) }} variant={ctx.alert.type} dismissible>
                                    {ctx.alert.msg}
                                </Alert>
                            </Container>
                        )
                    }
                </>
            )
        }
        return (
            <></>
        )

    }

}

export default MyAlert