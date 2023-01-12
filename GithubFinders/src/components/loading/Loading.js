import React from 'react'
import loadingImg from './loading.gif'
const Loading = () => {
  return (
    <>
        <img src={loadingImg} alt='Loading...' style={{width:'200px', display:'block', margin:'auto'}} />
    </>
  )
}

export default Loading