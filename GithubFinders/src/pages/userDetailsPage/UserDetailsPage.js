import React, { useContext, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { AppContext } from '../../contexts/AppContext';
import { Card, Col, Container, ListGroup, Row } from 'react-bootstrap';
import UserRepos from '../../components/userrepos/UserRepos';
const UserDetailsPage = () => {
    const ctx = useContext(AppContext);
    const { login } = useParams();
    useEffect(() => {
        ctx.getUser(login);
        ctx.getUsersRepos(login);
    }, []);
    return (

        <Container className='mt-3'>
            <Card>
                <Row>
                    <Col xs={4}>
                        <Card.Img className='d-flex aling-items-center p-3 pe-0' variant='top' src={ctx.user.avatar_url} />
                    </Col>
                    <Col xs={8}>

                        <Card.Header className='mt-3 me-3'>
                            <h1 className='display-6 fw-bold text-danger mb-1'>{ctx.user.login}</h1>
                        </Card.Header>
                        <Card.Body className='pb-0'>
                            <p className="m-0">{ctx.user.bio}</p>
                        </Card.Body>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <Card.Body>
                            <ListGroup>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Location: </h6><span className='ms-1'>{ctx.user.location}</span>
                                </ListGroup.Item>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Followers: </h6><span className='ms-1'>{ctx.user.followers}</span>
                                </ListGroup.Item>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Following: </h6><span className='ms-1'>{ctx.user.following}</span>
                                </ListGroup.Item>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Blog: </h6><span className='ms-1'>
                                        <a href={ctx.user.blog}>Visit to blog</a>
                                    </span>
                                </ListGroup.Item>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Company: </h6><span className='ms-1'>
                                        {ctx.user.company}
                                    </span>
                                </ListGroup.Item>
                                <ListGroup.Item className='d-flex align-items-center'>
                                    <h6 className='m-0'>Twitter: </h6><span className='ms-1'>
                                        {ctx.user.twitter_username}
                                    </span>
                                </ListGroup.Item>
                            </ListGroup>
                        </Card.Body>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <ListGroup>
                            <ListGroup.Item className='m-3'>
                                <UserRepos />
                            </ListGroup.Item>
                        </ListGroup>
                    </Col>
                </Row>
                <Row>
                    <Col>
                        <ListGroup>
                            <ListGroup.Item className='d-flex align-items-center'>
                                <div className='d-grid w-100'>
                                    <a className='btn btn-success' href={ctx.user.html_url} target='_blank'>Go to Github Profile</a>
                                </div>
                            </ListGroup.Item>
                        </ListGroup>
                    </Col>
                </Row>
            </Card>
        </Container>
    )
}

export default UserDetailsPage