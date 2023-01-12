import React, { useContext } from 'react'
import { AppContext } from '../../contexts/AppContext'
const UserRepo = ({ nextRepo }) => {
    return (
        <div className='mb-3'>
            <div className='d-flex align-items-center'>
                <span className='text-success fw-bold me-2'>{nextRepo.name}</span>
                <a className='btn btn-link fw-bold' href={nextRepo.html_url} target='_blank'>Go this repo!</a>
            </div>
        </div>
    )
}

export default UserRepo