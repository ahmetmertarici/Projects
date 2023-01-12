import React, { useContext, useEffect, useState } from 'react'
import { Button, Container, Form, InputGroup } from 'react-bootstrap'
import { AppContext } from '../../contexts/AppContext';

const Search = () => {
    const ctx = useContext(AppContext);
    const [keyword, setKeyword] = useState('');
    useEffect(() => {
        setKeyword('');
    }, [])
    const handleSubmit = (e) => {
        e.preventDefault();
        ctx.clearUsers();
        if (keyword === '') {
            ctx.initAlert('Lütfen boş bırakmayınız!', 'danger');
            ctx.setShow(true);
            ctx.setShowClearButton(false);
        } else {
            ctx.searchUsers(keyword);
        }
    };
    return (
        <>
            <Form onSubmit={handleSubmit} className='mt-3'>
                <Container>
                    <InputGroup>
                        <Form.Control onChange={(e) => setKeyword(e.target.value)} placeholder='Search...' />
                        <Button type='submit'>Search</Button>
                    </InputGroup>
                    {ctx.showClearButton &&
                        <div className='d-grid mt-3'>
                            <Button onClick={ctx.clearUsers} variant='danger' >Clear Result</Button>
                        </div>
                    }
                </Container>
            </Form>
        </>
    )
}

export default Search