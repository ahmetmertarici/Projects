import React, { useContext, useEffect } from 'react'
import { AppContext } from '../../contexts/AppContext'
import UserRepo from './UserRepo';
const UserRepos = () => {
    const ctx = useContext(AppContext);
    return (
        <>
            <h1 className='display-3 mb-3'>UserRepos</h1>
            {
                ctx.usersRepos.map((u) =>
                    <UserRepo nextRepo={u} key={u.id} />
                )
            }
        </>
    )
}

export default UserRepos